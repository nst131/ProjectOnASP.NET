using DomainYandexMusic.UnitOfWork;
using InfastructureYandexMusic.Context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace InfastructureYandexMusic.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICoreDbContext db;

        public UnitOfWork(ICoreDbContext db)
        {
            this.db = db;
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return db.Set<TEntity>();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return db.Entry(entity);
        }
    }
}
