using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteWeb.Migrations
{
    /// <inheritdoc />
    public partial class Produitprd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "CommandeDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommandeDetail_ProduitId",
                table: "CommandeDetail",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeDetail_Produits_ProduitId",
                table: "CommandeDetail",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandeDetail_Produits_ProduitId",
                table: "CommandeDetail");

            migrationBuilder.DropIndex(
                name: "IX_CommandeDetail_ProduitId",
                table: "CommandeDetail");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "CommandeDetail");
        }
    }
}
