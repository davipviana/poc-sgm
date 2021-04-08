using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenServices.Migrations
{
    public partial class AddCollumns_TaxValueCitizenId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CitizenId",
                table: "CitizenProperties",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TaxValue",
                table: "CitizenProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitizenId",
                table: "CitizenProperties");

            migrationBuilder.DropColumn(
                name: "TaxValue",
                table: "CitizenProperties");
        }
    }
}
