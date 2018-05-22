using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Workout_Planner.Data.Migrations
{
    public partial class WorkoutExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastCompleted = table.Column<DateTime>(nullable: false),
                    ProgamWeekID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutDay",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstimatedOneRepMax = table.Column<double>(nullable: false),
                    ExerciseID = table.Column<int>(nullable: false),
                    GoalRPE = table.Column<int>(nullable: false),
                    GoalReps = table.Column<int>(nullable: false),
                    GoalWeight = table.Column<double>(nullable: false),
                    GoalWeightPercentage = table.Column<double>(nullable: false),
                    LastCompletedID = table.Column<int>(nullable: false),
                    NumberSets = table.Column<int>(nullable: false),
                    ProgressionPercentage = table.Column<int>(nullable: false),
                    WorkoutID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDay", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "WorkoutDay");
        }
    }
}
