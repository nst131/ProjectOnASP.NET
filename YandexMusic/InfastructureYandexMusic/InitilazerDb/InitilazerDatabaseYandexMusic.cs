using DomainYandexMusic.Entities;
using InfastructureYandexMusic.ApplicationManagers;
using InfastructureYandexMusic.Context;
using InfastructureYandexMusic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;

namespace InfastructureYandexMusic.InitilazerDb
{
    public class InitilazerDatabaseYandexMusic : CreateDatabaseIfNotExists<CoreDbContext>
    {
        protected override void Seed(CoreDbContext db)
        {
            if (!db.Set<Popular>().Any())
            {
                Popular Popular = new Popular() { Name = KindOfTrack.Popular };
                Popular NotPopular = new Popular() { Name = KindOfTrack.NoPopular };

                db.Set<Popular>().Add(Popular);
                db.Set<Popular>().Add(NotPopular);
                db.SaveChanges();
            }

            if (!db.Set<Novelty>().Any())
            {
                Novelty Novelty = new Novelty() { Name = KindOfTrack.Novelty };
                Novelty NotNovelty = new Novelty() { Name = KindOfTrack.NoNovelty };

                db.Set<Novelty>().Add(Novelty);
                db.Set<Novelty>().Add(NotNovelty);
                db.SaveChanges();
            }

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));

            if (!roleManager.RoleExists(TypesRoles.Admin))
            {
                var role1 = new ApplicationRole { Name = TypesRoles.Admin };
                var role2 = new ApplicationRole { Name = TypesRoles.User };

                roleManager.Create(role1);
                roleManager.Create(role2);

                var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = TypesRoles.Admin, EmailConfirmed = true };
                string password = "admin";
                var result = userManager.Create(admin, password);

                if (result.Succeeded)
                {
                    userManager.AddToRole(admin.Id, role1.Name);
                    userManager.AddToRole(admin.Id, role2.Name);
                }
            }

            base.Seed(db);
        }
    }
}
