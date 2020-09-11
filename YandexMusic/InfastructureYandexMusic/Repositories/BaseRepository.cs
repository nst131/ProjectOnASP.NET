﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainYandexMusic.Repositories;
using DomainYandexMusic.UnitOfWork;

namespace InfastructureYandexMusic.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private IUnitOfWork unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int Count()
        {
            return DbSet().Count();
        }

        public void Create(T item)
        {

            DbSet().Add(item);
        }

        public void Delete(T item)
        {
            DbSet().Remove(item);
        }

        public T Get(object id)
        {
            return DbSet().Find(id);
        }

        protected virtual IQueryable<T> GetAll()
        {
            return DbSet();
        }

        protected virtual IQueryable<T> GetItems()
        {
            return DbSet().AsQueryable();
        }

        private DbSet<T> DbSet()
        {
            return unitOfWork.Set<T>();
        }
    }
}
