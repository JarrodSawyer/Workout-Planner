using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Workout_Planner.Data.Migrations
{
    public partial class SequenceNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseSequenceNum",
                table: "WorkoutDay",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutSequenceNum",
                table: "Workout",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeekSequenceNum",
                table: "ProgramWeek",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseSequenceNum",
                table: "WorkoutDay");

            migrationBuilder.DropColumn(
                name: "WorkoutSequenceNum",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "WeekSequenceNum",
                table: "ProgramWeek");
        }
    }
}
