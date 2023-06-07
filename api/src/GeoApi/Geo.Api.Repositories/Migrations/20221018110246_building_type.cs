using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGIS.Api.Repositories.Migrations
{
    public partial class building_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                schema: "public",
                table: "buildings",
                newName: "building_type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "building_type",
                schema: "public",
                table: "buildings",
                newName: "type");
        }
    }
}
