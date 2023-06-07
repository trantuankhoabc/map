using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGIS.Api.Repositories.Migrations
{
    public partial class active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                schema: "public",
                table: "buildings",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isactive",
                schema: "public",
                table: "buildings");
        }
    }
}
