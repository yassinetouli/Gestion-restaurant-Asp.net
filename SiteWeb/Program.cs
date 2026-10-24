using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiteWeb.Data;
using SiteWeb.Repos;
using SiteWeb.Services;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// ------------------------
// Add services to the container
// ------------------------
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<ProduitServices>();
builder.Services.AddScoped<ProduitRepos>();



// Register DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnnDB")));

// Add session services BEFORE Build
builder.Services.AddDistributedMemoryCache(); // Required for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1); // session lasts 1 hour
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// ------------------------
// Apply pending migrations automatically
// ------------------------
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    
    try
    {
        var context = services.GetRequiredService<MyDbContext>();
        
        logger.LogInformation("Checking for pending database migrations...");
        
        var pendingMigrations = context.Database.GetPendingMigrations().ToList();
        
        if (pendingMigrations.Any())
        {
            logger.LogInformation("Found {Count} pending migration(s): {Migrations}", 
                pendingMigrations.Count, 
                string.Join(", ", pendingMigrations));
            
            logger.LogInformation("Applying migrations...");
            context.Database.Migrate();
            
            logger.LogInformation("Database migrations applied successfully.");
        }
        else
        {
            logger.LogInformation("No pending migrations. Verifying database schema...");
            
            // Force apply migrations even if marked as applied (in case of schema mismatch)
            try
            {
                context.Database.Migrate();
                logger.LogInformation("Database schema verified.");
            }
            catch (Exception migrateEx)
            {
                logger.LogWarning(migrateEx, "Migration check completed with warnings.");
            }
        }
        
        // Additional check: Verify Adresse column exists, create if missing
        try
        {
            var connection = context.Database.GetDbConnection();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            
            using var command = connection.CreateCommand();
            
            // Check if Adresse column exists in Utilisateur table
            command.CommandText = @"
                IF NOT EXISTS (SELECT * FROM sys.columns 
                               WHERE object_id = OBJECT_ID(N'[dbo].[Utilisateur]') 
                               AND name = 'Adresse')
                BEGIN
                    ALTER TABLE [dbo].[Utilisateur] ADD [Adresse] nvarchar(max) NULL;
                END";
            
            command.ExecuteNonQuery();
            logger.LogInformation("Verified Adresse column in Utilisateur table.");
            
            // Check if Adresse column exists in CommandeDetail table
            command.CommandText = @"
                IF NOT EXISTS (SELECT * FROM sys.columns 
                               WHERE object_id = OBJECT_ID(N'[dbo].[CommandeDetail]') 
                               AND name = 'Adresse')
                BEGIN
                    ALTER TABLE [dbo].[CommandeDetail] ADD [Adresse] nvarchar(max) NULL;
                END";
            
            command.ExecuteNonQuery();
            logger.LogInformation("Verified Adresse column in CommandeDetail table.");
            
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            
            logger.LogInformation("Database schema verification completed.");
        }
        catch (Exception schemaEx)
        {
            logger.LogWarning(schemaEx, "Schema verification completed with warnings. This is normal if columns already exist.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database. Application startup will continue, but database operations may fail.");
        // Don't throw - allow app to start so user can see the error
    }
}

// ------------------------
// Configure the HTTP request pipeline
// ------------------------
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Make sure session is before auth & endpoints
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// MVC route + Razor Pages
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
