using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGIS.Api.Repositories.Migrations
{
    public partial class Feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type",
                schema: "public",
                table: "buildings",
                type: "text",
                defaultValue: "Feature",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                schema: "public",
                table: "buildings");
        }
    }
}
