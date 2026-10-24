using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteWeb.Migrations
{
    /// <inheritdoc />
    public partial class addfkcommande : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Produits_ProduitId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Utilisateur_UserId",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_UserId",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Commande");

            migrationBuilder.RenameColumn(
                name: "ProduitId",
                table: "Commande",
                newName: "produitId");

            migrationBuilder.RenameIndex(
                name: "IX_Commande_ProduitId",
                table: "Commande",
                newName: "IX_Commande_produitId");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_clientId",
                table: "Commande",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Produits_produitId",
                table: "Commande",
                column: "produitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Utilisateur_clientId",
                table: "Commande",
                column: "clientId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Produits_produitId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Utilisateur_clientId",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_clientId",
                table: "Commande");

            migrationBuilder.RenameColumn(
                name: "produitId",
                table: "Commande",
                newName: "ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_Commande_produitId",
                table: "Commande",
                newName: "IX_Commande_ProduitId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Commande",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commande_UserId",
                table: "Commande",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Produits_ProduitId",
                table: "Commande",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Utilisateur_UserId",
                table: "Commande",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
