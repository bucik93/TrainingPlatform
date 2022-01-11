using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingPlatform.DataAccess.Migrations
{
    public partial class AddManyToManyExercisePlanBugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePlans_Plans_ExerciseId",
                table: "ExercisePlans");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePlans_Plans_PlanId",
                table: "ExercisePlans",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePlans_Plans_PlanId",
                table: "ExercisePlans");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePlans_Plans_ExerciseId",
                table: "ExercisePlans",
                column: "ExerciseId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
