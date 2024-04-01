using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalStatistics.ReportRepository.Migrations
{
    public partial class UptDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UptDate",
                table: "ArbitrationProceeding.LegalActions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UptDate",
                table: "ArbitrationProceeding.LawsuitsContent",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UptDate",
                table: "ArbitrationProceeding.LegalActions");

            migrationBuilder.DropColumn(
                name: "UptDate",
                table: "ArbitrationProceeding.LawsuitsContent");
        }
    }
}
