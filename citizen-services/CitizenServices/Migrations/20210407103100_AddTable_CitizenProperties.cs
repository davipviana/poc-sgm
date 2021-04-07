using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenServices.Migrations
{
    public partial class AddTable_CitizenProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CitizenPropertyTypes",
                columns: table => new
                {
                    CitizenPropertyTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenPropertyTypes", x => x.CitizenPropertyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CitizenProperties",
                columns: table => new
                {
                    CitizenPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketValue = table.Column<double>(nullable: false),
                    CitizenPropertyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenProperties", x => x.CitizenPropertyId);
                    table.ForeignKey(
                        name: "FK_CitizenProperties_CitizenPropertyTypes_CitizenPropertyTypeId",
                        column: x => x.CitizenPropertyTypeId,
                        principalTable: "CitizenPropertyTypes",
                        principalColumn: "CitizenPropertyTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitizenProperties_CitizenPropertyTypeId",
                table: "CitizenProperties",
                column: "CitizenPropertyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitizenProperties");

            migrationBuilder.DropTable(
                name: "CitizenPropertyTypes");
        }
    }
}
