using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRest.Migrations
{
    public partial class relacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
