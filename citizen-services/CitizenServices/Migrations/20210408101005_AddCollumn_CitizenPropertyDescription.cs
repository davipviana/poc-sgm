using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenServices.Migrations
{
    public partial class AddCollumn_CitizenPropertyDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CitizenProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CitizenProperties");
        }
    }
}
