using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_2.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoneyDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donationAmount = table.Column<double>(type: "float", nullable: false),
                    dateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    donorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    disasteType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyDonations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyDonations");
        }
    }
}
