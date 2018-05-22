using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Workout_Planner.Data.Migrations
{
    public partial class DaysPerWeekandNumberOfWeeks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysPerWeek",
                table: "Program",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWeeks",
                table: "Program",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysPerWeek",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "NumberOfWeeks",
                table: "Program");
        }
    }
}
