using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRest.Migrations
{
    public partial class campoIdCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categoriaItems",
                newName: "categoriaId");

            migrationBuilder.AddColumn<int>(
                name: "fk_categoriaId",
                table: "videoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fk_categoriaId",
                table: "videoItems");

            migrationBuilder.RenameColumn(
                name: "categoriaId",
                table: "categoriaItems",
                newName: "Id");
        }
    }
}
