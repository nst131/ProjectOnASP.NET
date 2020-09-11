using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainYandexMusic.UnitOfWork;
using InfastructureYandexMusic.Context;

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

        public DbSet<TEntity> Set<TEntity>() where TEntity: class
        {
            return db.Set<TEntity>();
        }
    }
}
