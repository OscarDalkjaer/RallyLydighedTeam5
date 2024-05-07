using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseDataAccessModelId",
                table: "CourseDataAccessModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseDataAccessModels_ExerciseDataAccessModelId",
                table: "CourseDataAccessModels",
                column: "ExerciseDataAccessModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDataAccessModels_ExerciseDataAccessModels_ExerciseDataAccessModelId",
                table: "CourseDataAccessModels",
                column: "ExerciseDataAccessModelId",
                principalTable: "ExerciseDataAccessModels",
                principalColumn: "ExerciseDataAccessModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDataAccessModels_ExerciseDataAccessModels_ExerciseDataAccessModelId",
                table: "CourseDataAccessModels");

            migrationBuilder.DropIndex(
                name: "IX_CourseDataAccessModels_ExerciseDataAccessModelId",
                table: "CourseDataAccessModels");

            migrationBuilder.DropColumn(
                name: "ExerciseDataAccessModelId",
                table: "CourseDataAccessModels");
        }
    }
}
