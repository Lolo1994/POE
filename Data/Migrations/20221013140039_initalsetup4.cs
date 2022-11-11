using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_2.Data.Migrations
{
    public partial class initalsetup4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsAllocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    goodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateAllocated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    pricePerItem = table.Column<double>(type: "float", nullable: false),
                    disasterType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsAllocation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsAllocation");
        }
    }
}
