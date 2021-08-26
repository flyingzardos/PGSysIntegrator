using Microsoft.EntityFrameworkCore.Migrations;

namespace PGSysIntegrator.Infrastructure.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentObjectReferenceId",
                table: "DbReferenceContext",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteId",
                table: "DbReferenceContext",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentObjectReferenceId",
                table: "DbReferenceContext");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "DbReferenceContext");
        }
    }
}
