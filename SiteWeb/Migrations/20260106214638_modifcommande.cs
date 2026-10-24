using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteWeb.Migrations
{
    /// <inheritdoc />
    public partial class modifcommande : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Utilisateur_clientId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Utilisateur_livreurId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandeDetail_Utilisateur_UtilisateurId",
                table: "CommandeDetail");

            migrationBuilder.DropIndex(
                name: "IX_CommandeDetail_UtilisateurId",
                table: "CommandeDetail");

            migrationBuilder.DropIndex(
                name: "IX_Commande_clientId",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_livreurId",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "TotalTTC",
                table: "Commande");

            migrationBuilder.RenameColumn(
                name: "NCommande",
                table: "Commande",
                newName: "UserId");

            //migrationBuilder.AddColumn<string>(
            //    name: "Adresse",
            //    table: "Utilisateur",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "CommandeDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "Commande",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Utilisateur",
                keyColumn: "Id",
                keyValue: 10,
                column: "Adresse",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Commande_ProduitId",
                table: "Commande",
                column: "ProduitId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Produits_ProduitId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Utilisateur_UserId",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_ProduitId",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_UserId",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Utilisateur");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "Commande");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Commande",
                newName: "NCommande");

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "CommandeDetail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTTC",
                table: "Commande",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_CommandeDetail_UtilisateurId",
                table: "CommandeDetail",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_clientId",
                table: "Commande",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_livreurId",
                table: "Commande",
                column: "livreurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Utilisateur_clientId",
                table: "Commande",
                column: "clientId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Utilisateur_livreurId",
                table: "Commande",
                column: "livreurId",
                principalTable: "Utilisateur",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeDetail_Utilisateur_UtilisateurId",
                table: "CommandeDetail",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "Id");
        }
    }
}
