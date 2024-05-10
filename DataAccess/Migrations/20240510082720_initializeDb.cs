using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ExerciseDataAccessModels",
                newName: "TypeOfJump");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "ExerciseDataAccessModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExerciseDataAccessModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HandlingPosition",
                table: "ExerciseDataAccessModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "ExerciseDataAccessModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExerciseDataAccessModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Stationary",
                table: "ExerciseDataAccessModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WithCone",
                table: "ExerciseDataAccessModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ExerciseDataAccessModels",
                keyColumn: "ExerciseDataAccessModelId",
                keyValue: 1,
                columns: new[] { "Description", "HandlingPosition", "Level", "Name", "Stationary", "WithCone" },
                values: new object[] { "", 2, null, "", false, false });

            migrationBuilder.UpdateData(
                table: "ExerciseDataAccessModels",
                keyColumn: "ExerciseDataAccessModelId",
                keyValue: 2,
                columns: new[] { "Description", "HandlingPosition", "Level", "Name", "Stationary", "TypeOfJump", "WithCone" },
                values: new object[] { "", 2, null, "", false, null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExerciseDataAccessModels");

            migrationBuilder.DropColumn(
                name: "HandlingPosition",
                table: "ExerciseDataAccessModels");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "ExerciseDataAccessModels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExerciseDataAccessModels");

            migrationBuilder.DropColumn(
                name: "Stationary",
                table: "ExerciseDataAccessModels");

            migrationBuilder.DropColumn(
                name: "WithCone",
                table: "ExerciseDataAccessModels");

            migrationBuilder.RenameColumn(
                name: "TypeOfJump",
                table: "ExerciseDataAccessModels",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "ExerciseDataAccessModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseDataAccessModelId",
                table: "CourseDataAccessModels",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ExerciseDataAccessModels",
                keyColumn: "ExerciseDataAccessModelId",
                keyValue: 2,
                column: "Type",
                value: 2);

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
    }
}
