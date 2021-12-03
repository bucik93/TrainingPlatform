using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingPlatform.DataAccess.Migrations
{
    public partial class AddFieldExerciseIdToPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Plans");
        }
    }
}
