using InfastructureYandexMusic.InitilazerDb;
using System.Data.Entity;

namespace InfastructureYandexMusic.Context
{
    public class CoreDbContext : DbContext, ICoreDbContext
    {
        static CoreDbContext()
        {
            Database.SetInitializer<CoreDbContext>(new InitilazerDatabaseYandexMusic());
        }

        public CoreDbContext()
            : base("name = YandexMusicContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
