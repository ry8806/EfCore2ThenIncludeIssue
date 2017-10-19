using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfCore2Issue.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecificSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklySchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificDate",
                columns: table => new
                {
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SpecificScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificDate", x => new { x.Date, x.SpecificScheduleId });
                    table.ForeignKey(
                        name: "FK_SpecificDate_SpecificSchedule_SpecificScheduleId",
                        column: x => x.SpecificScheduleId,
                        principalTable: "SpecificSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Layer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    WeeklyScheduleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Layer_SpecificSchedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "SpecificSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Layer_WeeklySchedule_WeeklyScheduleId",
                        column: x => x.WeeklyScheduleId,
                        principalTable: "WeeklySchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holders_Layer_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holders_LayerId",
                table: "Holders",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Layer_ScheduleId",
                table: "Layer",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Layer_WeeklyScheduleId",
                table: "Layer",
                column: "WeeklyScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificDate_SpecificScheduleId",
                table: "SpecificDate",
                column: "SpecificScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holders");

            migrationBuilder.DropTable(
                name: "SpecificDate");

            migrationBuilder.DropTable(
                name: "Layer");

            migrationBuilder.DropTable(
                name: "SpecificSchedule");

            migrationBuilder.DropTable(
                name: "WeeklySchedule");
        }
    }
}
