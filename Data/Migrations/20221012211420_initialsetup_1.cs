using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_2.Data.Migrations
{
    public partial class initialsetup_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisasterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    disasterType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aidRequired = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisasterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodsDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    itemNumber = table.Column<int>(type: "int", nullable: false),
                    itemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    disasteType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDonations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisasterType");

            migrationBuilder.DropTable(
                name: "GoodsDonations");
        }
    }
}
