using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseDataAccessModels",
                columns: table => new
                {
                    CourseDataAccessModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDataAccessModels", x => x.CourseDataAccessModelId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDataAccessModels",
                columns: table => new
                {
                    ExerciseDataAccessModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandlingPosition = table.Column<int>(type: "int", nullable: false),
                    Stationary = table.Column<bool>(type: "bit", nullable: false),
                    WithCone = table.Column<bool>(type: "bit", nullable: false),
                    TypeOfJump = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDataAccessModels", x => x.ExerciseDataAccessModelId);
                });

            migrationBuilder.CreateTable(
                name: "Judges",
                columns: table => new
                {
                    JudgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judges", x => x.JudgeId);
                });

            migrationBuilder.CreateTable(
                name: "CourseExerciseRelations",
                columns: table => new
                {
                    CourseExerciseRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDataAccessModelId = table.Column<int>(type: "int", nullable: false),
                    ExerciseDataAccessModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseExerciseRelations", x => x.CourseExerciseRelationId);
                    table.ForeignKey(
                        name: "FK_CourseExerciseRelations_CourseDataAccessModels_CourseDataAccessModelId",
                        column: x => x.CourseDataAccessModelId,
                        principalTable: "CourseDataAccessModels",
                        principalColumn: "CourseDataAccessModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseExerciseRelations_ExerciseDataAccessModels_ExerciseDataAccessModelId",
                        column: x => x.ExerciseDataAccessModelId,
                        principalTable: "ExerciseDataAccessModels",
                        principalColumn: "ExerciseDataAccessModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExerciseDataAccessModels",
                columns: new[] { "ExerciseDataAccessModelId", "Description", "HandlingPosition", "Level", "Name", "Number", "Stationary", "TypeOfJump", "WithCone" },
                values: new object[,]
                {
                    { 1, "", 2, null, "", 777, false, null, false },
                    { 2, "", 2, null, "", 2, false, null, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseExerciseRelations_CourseDataAccessModelId",
                table: "CourseExerciseRelations",
                column: "CourseDataAccessModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExerciseRelations_ExerciseDataAccessModelId",
                table: "CourseExerciseRelations",
                column: "ExerciseDataAccessModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseExerciseRelations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Judges");

            migrationBuilder.DropTable(
                name: "CourseDataAccessModels");

            migrationBuilder.DropTable(
                name: "ExerciseDataAccessModels");
        }
    }
}
