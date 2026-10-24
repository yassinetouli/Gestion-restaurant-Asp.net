using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteWeb.Migrations
{
    /// <inheritdoc />
    public partial class removeprdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Produits_produitId",
                table: "Commande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_produitId",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "CommandeDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "CommandeDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commande_produitId",
                table: "Commande",
                column: "produitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Produits_produitId",
                table: "Commande",
                column: "produitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
