using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingPlatform.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Files_FileId",
                table: "Exercises");

            migrationBuilder.DropTable(
                name: "ContentFiles");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_FileId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "BothHands",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "OneHanded",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercises");

            migrationBuilder.AddColumn<bool>(
                name: "BothHands",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OneHanded",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Exercises",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_FileId",
                table: "Exercises",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentFiles_FileId",
                table: "ContentFiles",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Files_FileId",
                table: "Exercises",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
