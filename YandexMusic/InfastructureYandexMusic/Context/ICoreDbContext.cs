using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace InfastructureYandexMusic.Context
{
    public interface ICoreDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
