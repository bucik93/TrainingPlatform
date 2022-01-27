using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingPlatform.DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanUser");

            migrationBuilder.CreateTable(
                name: "PlanUsers",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanUsers", x => new { x.PlanId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PlanUsers_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "Link", "Name", "Repeat", "Series", "Weight" },
                values: new object[,]
                {
                    { 1, "martwy ciąg z kettlebell ustawiamy ciało w dokładnie taki sam sposób, jak przy podejściu do sztangi. Stajemy na szerokości bioder lub nieco szerzej, stopy kierując minimalnie na zewnątrz. Napinamy mięśnie brzucha i pośladów, ściągamy łopatki.", "https://www.youtube.com/watch?v=-rtEvBD7haM&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=1", "MARTWY CIĄG ODWAŻNIKIEM KULOWYM", 20, 10, 32 },
                    { 2, "Stań w rozkroku szerszym niż na szerokość bioder, kolana lekko zgięte – chwyć kettlebell w obie dłonie i wykonaj lekki wymach w tył, by odważnik znalazł się między nogami (nawet lekko za nimi), a następnie wypychając biodra do przodu, wykonaj wyrzut kettlebell przed siebie na wysokość klatki piersiowej. Wróć do pozycji wyjściowej. Ważne jest utrzymanie prostych pleców, wyprostowanych ramion.Swing może być wykonywany także na jedną rękę.", "https://www.youtube.com/watch?v=_NGSfoPgdgQ&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=2", "SWING ODWAŻNIKIEM KULOWYM", 18, 8, 28 },
                    { 3, "Trening nóg z kettlebell możesz rozpocząć właśnie od tego ćwiczenia. Stań w szerszym rozkroku i chwyć kettlebell, przyciągając go do klatki piersiowej, po czym wykonaj przysiad, nie zmieniając jego pozycji. Pamiętaj o tym, by linia kolan nie przekraczała linii palców.", "https://www.youtube.com/watch?v=03B7-XSO1MI&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=4", "PRZYSIAD Z ODWAŻNIKIEM", 16, 6, 24 },
                    { 4, "Stań w szerokim rozkroku, chwyć kettlebell jedną ręką i wykonaj zamach, by znalazł się między nogami. Następnie wypchnij biodra i wyrzuć go przed siebie – gdy znajdzie się na wysokości klatki piersiowej, szybko zegnij rękę w łokciu, by odważnik znalazł się blisko ciała. Łokieć powinien być przyklejony do klatki piersiowej, a odważnik na zewnętrznej stronie dłoni. Druga ręka powinna być wyprostowana w bok, pomagając utrzymać równowagę. Wróć do pozycji wyjściowej.", "https://www.youtube.com/watch?v=0LrZ3Tl8aSg&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=6", "ZARZUT ODWAŻNIKIEM KULOWYM JEDNORĄCZ CLEAN", 14, 4, 22 },
                    { 5, "Wstawanie tureckie (TGU) to ćwiczenie, które pomaga rozwinąć mobilność i stabilność w barkach, a statyczne obciążenie rozwija ich siłę. Dodatkowo wzmacnia stożki rotatorów poprzez przeciwdziałanie rotacji kettla wokół nadgarstka. TGU aktywuje wszystkie mięśnie brzucha, wzmacnia mięśnie głębokie oraz mięśnie obręczy kończyny dolnej. ", "https://www.youtube.com/watch?v=303ejRDjZX0&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=7", "TURECKIE WSTAWANIE Z ODWAŻNIKIEM KULOWYM TGU", 12, 2, 20 },
                    { 6, "Ćwiczenie jest zbliżone do Military Pressu, jednak różni się dynamiką. Rozstaw szeroko nogi, chwyć kettlebell w jedną dłoń, po czym wykonaj wymach w tył i wyciśnij go do przodu. Nie zatrzymuj się jednak w okolicy klatki piersiowej – od razu przenieś wyprostowaną rękę nad głowę. Kettlebell w ostatniej fazie ruchu powinien znaleźć się za dłonią. Wykonaj na obie strony ciała.", "https://www.youtube.com/watch?v=GG3e2MZS02w&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=11", "RWANIE ODWAŻNIKIEM KULOWYM", 14, 5, 34 }
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Trening A01" },
                    { 2, "Trening A02" },
                    { 3, "Trening A03" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "HashedPassword", "LastName", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, "Adam", "HO9i39jP5fA0/UOJ+l2PaKJS3wVsqZir7mck2NsuwBU=", "Kozioł", "2euNApDf3kkT/KNA6bkVpg==", "Adams" },
                    { 2, "Adam", "HO9i39jP5fA0/UOJ+l2PaKJS3wVsqZir7mck2NsuwBU=", "Kozioł", "2euNApDf3kkT/KNA6bkVpg==", "Adams" },
                    { 3, "Marek", "hKB8ZsIF4QPJyOmhjzN2xG0x3N3rwMPUVhmaS53qt5k=", "Nowak", "fsCKGWaGb3mcTnrRIu90pw==", "NowaM" },
                    { 4, "Artur", "Jv2JFt9d0OtEjbUZeLGBNqey3ZXeA3bztSo+FA1c9Qw=", "Mess", "lFYVXoG9W/w87+bNVXbTXg==", "Mace" },
                    { 5, "Jan", "kQsi7XDcqN9XLqnPZhwMjEtixruI/HotgmvaExfYCvg=", "Kowalski", "l6YlFQkg2G4yiKCwyeyhcg==", "kowal" }
                });

            migrationBuilder.InsertData(
                table: "ExercisePlans",
                columns: new[] { "ExerciseId", "PlanId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "PlanUsers",
                columns: new[] { "PlanId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanUsers_UserId",
                table: "PlanUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanUsers");

            migrationBuilder.DeleteData(
                table: "ExercisePlans",
                keyColumns: new[] { "ExerciseId", "PlanId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ExercisePlans",
                keyColumns: new[] { "ExerciseId", "PlanId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ExercisePlans",
                keyColumns: new[] { "ExerciseId", "PlanId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ExercisePlans",
                keyColumns: new[] { "ExerciseId", "PlanId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ExercisePlans",
                keyColumns: new[] { "ExerciseId", "PlanId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ExercisePlans",
                keyColumns: new[] { "ExerciseId", "PlanId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "PlanUser",
                columns: table => new
                {
                    PlansId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanUser", x => new { x.PlansId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PlanUser_Plans_PlansId",
                        column: x => x.PlansId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanUser_UsersId",
                table: "PlanUser",
                column: "UsersId");
        }
    }
}
