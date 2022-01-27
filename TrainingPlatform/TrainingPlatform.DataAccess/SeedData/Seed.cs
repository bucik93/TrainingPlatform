using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.SeedData
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(p =>
            {
                p.HasData(new Exercise()
                {
                    Id = 1,
                    Name = "MARTWY CIĄG ODWAŻNIKIEM KULOWYM",
                    Link = "https://www.youtube.com/watch?v=-rtEvBD7haM&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=1",
                    Description = "martwy ciąg z kettlebell ustawiamy ciało w dokładnie taki sam sposób, jak przy podejściu do sztangi. " +
                    "Stajemy na szerokości bioder lub nieco szerzej, stopy kierując minimalnie na zewnątrz. Napinamy mięśnie brzucha i pośladów, " +
                    "ściągamy łopatki.",
                    Repeat = 20,
                    Series = 10,
                    Weight = 32
                });
            });
            modelBuilder.Entity<Exercise>(p =>
            {
                p.HasData(new Exercise()
                {
                    Id = 2,
                    Name = "SWING ODWAŻNIKIEM KULOWYM",
                    Link = "https://www.youtube.com/watch?v=_NGSfoPgdgQ&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=2",
                    Description = "Stań w rozkroku szerszym niż na szerokość bioder, kolana lekko zgięte – chwyć kettlebell w obie dłonie i " +
                    "wykonaj lekki wymach w tył, by odważnik znalazł się między nogami (nawet lekko za nimi), a następnie wypychając biodra do" +
                    " przodu, wykonaj wyrzut kettlebell przed siebie na wysokość klatki piersiowej. Wróć do pozycji wyjściowej. Ważne jest" +
                    " utrzymanie prostych pleców, wyprostowanych ramion.Swing może być wykonywany także na jedną rękę.",
                    Repeat = 18,
                    Series = 8,
                    Weight = 28
                });
            });
            modelBuilder.Entity<Exercise>(p =>
            {
                p.HasData(new Exercise()
                {
                    Id = 3,
                    Name = "PRZYSIAD Z ODWAŻNIKIEM",
                    Link = "https://www.youtube.com/watch?v=03B7-XSO1MI&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=4",
                    Description = "Trening nóg z kettlebell możesz rozpocząć właśnie od tego ćwiczenia. Stań w szerszym rozkroku i " +
                    "chwyć kettlebell, przyciągając go do klatki piersiowej, po czym wykonaj przysiad, nie zmieniając jego pozycji." +
                    " Pamiętaj o tym, by linia kolan nie przekraczała linii palców.",
                    Repeat = 16,
                    Series = 6,
                    Weight = 24
                });
            });
            modelBuilder.Entity<Exercise>(p =>
            {
                p.HasData(new Exercise()
                {
                    Id = 4,
                    Name = "ZARZUT ODWAŻNIKIEM KULOWYM JEDNORĄCZ CLEAN",
                    Link = "https://www.youtube.com/watch?v=0LrZ3Tl8aSg&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=6",
                    Description = "Stań w szerokim rozkroku, chwyć kettlebell jedną ręką i wykonaj zamach, by znalazł się między nogami. " +
                    "Następnie wypchnij biodra i wyrzuć go przed siebie – gdy znajdzie się na wysokości klatki piersiowej, szybko zegnij" +
                    " rękę w łokciu, by odważnik znalazł się blisko ciała. Łokieć powinien być przyklejony do klatki piersiowej, a odważnik " +
                    "na zewnętrznej stronie dłoni. Druga ręka powinna być wyprostowana w bok, pomagając utrzymać równowagę. Wróć do pozycji wyjściowej.",
                    Repeat = 14,
                    Series = 4,
                    Weight = 22
                });
            });
            modelBuilder.Entity<Exercise>(p =>
            {
                p.HasData(new Exercise()
                {
                    Id = 5,
                    Name = "TURECKIE WSTAWANIE Z ODWAŻNIKIEM KULOWYM TGU",
                    Link = "https://www.youtube.com/watch?v=303ejRDjZX0&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=7",
                    Description = "Wstawanie tureckie (TGU) to ćwiczenie, które pomaga rozwinąć mobilność i stabilność w barkach, a " +
                    "statyczne obciążenie rozwija ich siłę. Dodatkowo wzmacnia stożki rotatorów poprzez przeciwdziałanie rotacji kettla" +
                    " wokół nadgarstka. TGU aktywuje wszystkie mięśnie brzucha, wzmacnia mięśnie głębokie oraz mięśnie obręczy kończyny dolnej. ",
                    Repeat = 12,
                    Series = 2,
                    Weight = 20
                });
            });
            modelBuilder.Entity<Exercise>(p =>
            {
                p.HasData(new Exercise()
                {
                    Id = 6,
                    Name = "RWANIE ODWAŻNIKIEM KULOWYM",
                    Link = "https://www.youtube.com/watch?v=GG3e2MZS02w&list=PLafWxHJll3dV12nuEWKrWfgqxbr1EtHbZ&index=11",
                    Description = "Ćwiczenie jest zbliżone do Military Pressu, jednak różni się dynamiką. Rozstaw szeroko nogi, chwyć " +
                    "kettlebell w jedną dłoń, po czym wykonaj wymach w tył i wyciśnij go do przodu. Nie zatrzymuj się jednak w okolicy" +
                    " klatki piersiowej – od razu przenieś wyprostowaną rękę nad głowę. Kettlebell w ostatniej fazie ruchu powinien znaleźć" +
                    " się za dłonią. Wykonaj na obie strony ciała.",
                    Repeat = 14,
                    Series = 5,
                    Weight = 34
                });
            });
            modelBuilder.Entity<User>(p =>
            {
                p.HasData(new User()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Kozioł",
                    Salt = "2euNApDf3kkT/KNA6bkVpg==",
                    HashedPassword = "HO9i39jP5fA0/UOJ+l2PaKJS3wVsqZir7mck2NsuwBU=",
                    Username = "Adams"
                });
            });
            modelBuilder.Entity<User>(p =>
            {
                p.HasData(new User()
                {
                    Id = 2,
                    FirstName = "Adam",
                    LastName = "Kozioł",
                    Salt = "2euNApDf3kkT/KNA6bkVpg==",
                    HashedPassword = "HO9i39jP5fA0/UOJ+l2PaKJS3wVsqZir7mck2NsuwBU=",
                    Username = "Adams"
                });
            });
            modelBuilder.Entity<User>(p =>
            {
                p.HasData(new User()
                {
                    Id = 3,
                    FirstName = "Marek",
                    LastName = "Nowak",
                    Salt = "fsCKGWaGb3mcTnrRIu90pw==",
                    HashedPassword = "hKB8ZsIF4QPJyOmhjzN2xG0x3N3rwMPUVhmaS53qt5k=",
                    Username = "NowaM"
                });
            });
            modelBuilder.Entity<User>(p =>
            {
                p.HasData(new User()
                {
                    Id = 4,
                    FirstName = "Artur",
                    LastName = "Mess",
                    Salt = "lFYVXoG9W/w87+bNVXbTXg==",
                    HashedPassword = "Jv2JFt9d0OtEjbUZeLGBNqey3ZXeA3bztSo+FA1c9Qw=",
                    Username = "Mace"
                    
                });
            });
            modelBuilder.Entity<User>(p =>
            {
                p.HasData(new User()
                {
                    Id = 5,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Salt = "l6YlFQkg2G4yiKCwyeyhcg==",
                    HashedPassword = "kQsi7XDcqN9XLqnPZhwMjEtixruI/HotgmvaExfYCvg=",
                    Username = "kowal"
                });
            });


            modelBuilder.Entity<Plan>(p =>
            {
                p.HasData(new Plan()
                {
                    Id = 1,
                    Name = "Trening A01"                    
                });
            });
    
            modelBuilder.Entity<Plan>(p =>
            {
                p.HasData(new Plan()
                {
                    Id = 2,
                    Name = "Trening A02"
                });
            });
            modelBuilder.Entity<Plan>(p =>
            {
                p.HasData(new Plan()
                {
                    Id = 3,
                    Name = "Trening A03"
                });
            });

            modelBuilder.Entity<ExercisePlan>(p =>
            {
                p.HasData(new ExercisePlan()
                {
                    ExerciseId = 1,
                    PlanId =1                    
                });
            });
            modelBuilder.Entity<ExercisePlan>(p =>
            {
                p.HasData(new ExercisePlan()
                {
                    ExerciseId = 2,
                    PlanId = 1
                });
            });
            modelBuilder.Entity<ExercisePlan>(p =>
            {
                p.HasData(new ExercisePlan()
                {
                    ExerciseId = 3,
                    PlanId = 1
                });
            });

            modelBuilder.Entity<ExercisePlan>(p =>
            {
                p.HasData(new ExercisePlan()
                {
                    ExerciseId = 4,
                    PlanId = 2
                });
            });
            modelBuilder.Entity<ExercisePlan>(p =>
            {
                p.HasData(new ExercisePlan()
                {
                    ExerciseId = 5,
                    PlanId = 2
                });
            });
            modelBuilder.Entity<ExercisePlan>(p =>
            {
                p.HasData(new ExercisePlan()
                {
                    ExerciseId = 6,
                    PlanId = 3
                });
            });

      
            modelBuilder.Entity<PlanUser>(p =>
            {
                p.HasData(new PlanUser()
                {
                    UserId = 1,
                    PlanId = 1
                });
            });
            modelBuilder.Entity<PlanUser>(p =>
            {
                p.HasData(new PlanUser()
                {
                    UserId = 1,
                    PlanId = 2
                });
            });
            modelBuilder.Entity<PlanUser>(p =>
            {
                p.HasData(new PlanUser()
                {
                    UserId = 1,
                    PlanId = 3
                });
            });
        }
    }
}
