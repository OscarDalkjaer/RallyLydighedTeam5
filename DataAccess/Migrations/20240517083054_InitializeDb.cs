using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultHandlingPosition",
                table: "ExerciseDataAccessModels",
                newName: "HandlingPosition");

            migrationBuilder.UpdateData(
                table: "ExerciseDataAccessModels",
                keyColumn: "ExerciseDataAccessModelId",
                keyValue: 1,
                column: "HandlingPosition",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ExerciseDataAccessModels",
                keyColumn: "ExerciseDataAccessModelId",
                keyValue: 2,
                column: "HandlingPosition",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HandlingPosition",
                table: "ExerciseDataAccessModels",
                newName: "DefaultHandlingPosition");

            migrationBuilder.UpdateData(
                table: "ExerciseDataAccessModels",
                keyColumn: "ExerciseDataAccessModelId",
                keyValue: 1,
                column: "DefaultHandlingPosition",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ExerciseDataAccessModels",
                keyColumn: "ExerciseDataAccessModelId",
                keyValue: 2,
                column: "DefaultHandlingPosition",
                value: 0);
        }
    }
}
