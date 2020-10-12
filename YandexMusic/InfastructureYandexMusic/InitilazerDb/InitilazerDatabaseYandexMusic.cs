using DomainYandexMusic.Entities;
using InfastructureYandexMusic.Context;
using System.Data.Entity;
using System.Linq;

namespace InfastructureYandexMusic.InitilazerDb
{
    public class InitilazerDatabaseYandexMusic : DropCreateDatabaseAlways<CoreDbContext>
    {
        protected override void Seed(CoreDbContext db)
        {
            if (!db.Set<Popular>().Any())
            {
                Popular Popular = new Popular() { Name = "Популярное" };
                Popular NotPopular = new Popular() { Name = "Неизвестное" };

                db.Set<Popular>().Add(Popular);
                db.Set<Popular>().Add(NotPopular);
                db.SaveChanges();
            }

            if (!db.Set<Novelty>().Any())
            {
                Novelty Novelty = new Novelty() { Name = "Новинка" };
                Novelty NotNovelty = new Novelty() { Name = "Традиционная" };

                db.Set<Novelty>().Add(Novelty);
                db.Set<Novelty>().Add(NotNovelty);
                db.SaveChanges();
            }

            base.Seed(db);
        }
    }
}
