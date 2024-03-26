using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LegalStatistics.ReportRepository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArbitrationProceeding.LawsuitsContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ordinal = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbitrationProceeding.LawsuitsContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArbitrationProceeding.LegalActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ordinal = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbitrationProceeding.LegalActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArbitrationProceeding.Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LawsuitContentId = table.Column<int>(type: "integer", nullable: false),
                    LegalActionId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    ReportingYear = table.Column<int>(type: "integer", nullable: false),
                    ReportingPeriod = table.Column<byte>(type: "smallint", nullable: false),
                    FillDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbitrationProceeding.Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArbitrationProceeding.Statistics_ArbitrationProceeding.Laws~",
                        column: x => x.LawsuitContentId,
                        principalTable: "ArbitrationProceeding.LawsuitsContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArbitrationProceeding.Statistics_ArbitrationProceeding.Lega~",
                        column: x => x.LegalActionId,
                        principalTable: "ArbitrationProceeding.LegalActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrationProceeding.Statistics_LawsuitContentId",
                table: "ArbitrationProceeding.Statistics",
                column: "LawsuitContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrationProceeding.Statistics_LegalActionId",
                table: "ArbitrationProceeding.Statistics",
                column: "LegalActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArbitrationProceeding.Statistics");

            migrationBuilder.DropTable(
                name: "ArbitrationProceeding.LawsuitsContent");

            migrationBuilder.DropTable(
                name: "ArbitrationProceeding.LegalActions");
        }
    }
}
