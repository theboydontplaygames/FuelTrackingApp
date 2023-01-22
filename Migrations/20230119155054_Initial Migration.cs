using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelTrackingapplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelData",
                columns: table => new
                {
                    dataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reportingEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    odometerTotal = table.Column<int>(type: "int", nullable: false),
                    filledVolume = table.Column<int>(type: "int", nullable: false),
                    fuelPrice = table.Column<int>(type: "int", nullable: false),
                    filled = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelData", x => x.dataId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelData");
        }
    }
}
