﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBooking.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymClass",
                columns: table => new
                {
                    GymClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymClass", x => x.GymClassId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserGymClass",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GymClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGymClass", x => new { x.ApplicationUserId, x.GymClassId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_GymClass_GymClassId",
                        column: x => x.GymClassId,
                        principalTable: "GymClass",
                        principalColumn: "GymClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGymClass_GymClassId",
                table: "ApplicationUserGymClass",
                column: "GymClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserGymClass");

            migrationBuilder.DropTable(
                name: "GymClass");
        }
    }
}
