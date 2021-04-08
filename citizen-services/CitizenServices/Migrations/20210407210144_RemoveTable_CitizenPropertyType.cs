using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenServices.Migrations
{
    public partial class RemoveTable_CitizenPropertyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenProperties_CitizenPropertyTypes_CitizenPropertyTypeId",
                table: "CitizenProperties");

            migrationBuilder.DropTable(
                name: "CitizenPropertyTypes");

            migrationBuilder.DropIndex(
                name: "IX_CitizenProperties_CitizenPropertyTypeId",
                table: "CitizenProperties");

            migrationBuilder.DropColumn(
                name: "CitizenPropertyTypeId",
                table: "CitizenProperties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitizenPropertyTypeId",
                table: "CitizenProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CitizenPropertyTypes",
                columns: table => new
                {
                    CitizenPropertyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenPropertyTypes", x => x.CitizenPropertyTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitizenProperties_CitizenPropertyTypeId",
                table: "CitizenProperties",
                column: "CitizenPropertyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenProperties_CitizenPropertyTypes_CitizenPropertyTypeId",
                table: "CitizenProperties",
                column: "CitizenPropertyTypeId",
                principalTable: "CitizenPropertyTypes",
                principalColumn: "CitizenPropertyTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
