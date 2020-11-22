using InfastructureYandexMusic.InitilazerDb;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace InfastructureYandexMusic.Context
{
    public class CoreDbContext : IdentityDbContext, ICoreDbContext
    {
        static CoreDbContext()
        {
            Database.SetInitializer(new InitilazerDatabaseYandexMusic());
        }

        public CoreDbContext()
            : base("name = YandexMusicContext")
        {
            
        }

        public static CoreDbContext Create()
        {
            return new CoreDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
