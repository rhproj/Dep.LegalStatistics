using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LegalStatistics.ReportRepository.Migrations
{
    public partial class CivilRightsStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArbitrationProceeding.Statistics_ArbitrationProceeding.Laws~",
            //    table: "ArbitrationProceeding.Statistics");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArbitrationProceeding.Statistics_ArbitrationProceeding.Lega~",
            //    table: "ArbitrationProceeding.Statistics");

            migrationBuilder.CreateTable(
                name: "CivilRights.LawsuitsContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ordinal = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UptDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilRights.LawsuitsContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivilRights.LegalActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ordinal = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UptDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilRights.LegalActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivilRights.Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    ReportingYear = table.Column<int>(type: "integer", nullable: false),
                    ReportingPeriod = table.Column<byte>(type: "smallint", nullable: false),
                    FillDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LawsuitContentId = table.Column<int>(type: "integer", nullable: false),
                    LegalActionId = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilRights.Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CivilRights.Statistics_CivilRights.LawsuitsContent_LawsuitC~",
                        column: x => x.LawsuitContentId,
                        principalTable: "CivilRights.LawsuitsContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CivilRights.Statistics_CivilRights.LegalActions_LegalAction~",
                        column: x => x.LegalActionId,
                        principalTable: "CivilRights.LegalActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CivilRights.Statistics_LawsuitContentId",
                table: "CivilRights.Statistics",
                column: "LawsuitContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CivilRights.Statistics_LegalActionId",
                table: "CivilRights.Statistics",
                column: "LegalActionId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArbitrationProceeding.Statistics_CivilRights.LawsuitsConten~",
            //    table: "ArbitrationProceeding.Statistics",
            //    column: "LawsuitContentId",
            //    principalTable: "CivilRights.LawsuitsContent",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArbitrationProceeding.Statistics_CivilRights.LegalActions_L~",
            //    table: "ArbitrationProceeding.Statistics",
            //    column: "LegalActionId",
            //    principalTable: "CivilRights.LegalActions",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArbitrationProceeding.Statistics_CivilRights.LawsuitsConten~",
            //    table: "ArbitrationProceeding.Statistics");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ArbitrationProceeding.Statistics_CivilRights.LegalActions_L~",
            //    table: "ArbitrationProceeding.Statistics");

            migrationBuilder.DropTable(
                name: "CivilRights.Statistics");

            migrationBuilder.DropTable(
                name: "CivilRights.LawsuitsContent");

            migrationBuilder.DropTable(
                name: "CivilRights.LegalActions");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArbitrationProceeding.Statistics_ArbitrationProceeding.Laws~",
            //    table: "ArbitrationProceeding.Statistics",
            //    column: "LawsuitContentId",
            //    principalTable: "ArbitrationProceeding.LawsuitsContent",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ArbitrationProceeding.Statistics_ArbitrationProceeding.Lega~",
            //    table: "ArbitrationProceeding.Statistics",
            //    column: "LegalActionId",
            //    principalTable: "ArbitrationProceeding.LegalActions",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
