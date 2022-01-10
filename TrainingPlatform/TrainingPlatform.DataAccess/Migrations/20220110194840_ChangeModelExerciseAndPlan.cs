using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingPlatform.DataAccess.Migrations
{
    public partial class ChangeModelExerciseAndPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Plans");

            migrationBuilder.CreateTable(
                name: "ExercisePlan",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    PlansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisePlan", x => new { x.ExercisesId, x.PlansId });
                    table.ForeignKey(
                        name: "FK_ExercisePlan_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisePlan_Plans_PlansId",
                        column: x => x.PlansId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePlan_PlansId",
                table: "ExercisePlan",
                column: "PlansId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercisePlan");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
