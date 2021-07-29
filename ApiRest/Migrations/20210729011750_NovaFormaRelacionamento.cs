using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRest.Migrations
{
    public partial class NovaFormaRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videoItems_categoriaItems_categoriascategoriaId",
                table: "videoItems");

            migrationBuilder.DropIndex(
                name: "IX_videoItems_categoriascategoriaId",
                table: "videoItems");

            migrationBuilder.DropColumn(
                name: "categoriascategoriaId",
                table: "videoItems");

            migrationBuilder.CreateIndex(
                name: "IX_videoItems_fk_categoriaId",
                table: "videoItems",
                column: "fk_categoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_videoItems_categoriaItems_fk_categoriaId",
                table: "videoItems",
                column: "fk_categoriaId",
                principalTable: "categoriaItems",
                principalColumn: "categoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videoItems_categoriaItems_fk_categoriaId",
                table: "videoItems");

            migrationBuilder.DropIndex(
                name: "IX_videoItems_fk_categoriaId",
                table: "videoItems");

            migrationBuilder.AddColumn<int>(
                name: "categoriascategoriaId",
                table: "videoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_videoItems_categoriascategoriaId",
                table: "videoItems",
                column: "categoriascategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_videoItems_categoriaItems_categoriascategoriaId",
                table: "videoItems",
                column: "categoriascategoriaId",
                principalTable: "categoriaItems",
                principalColumn: "categoriaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
