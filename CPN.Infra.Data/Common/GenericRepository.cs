using CPN.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CPN.Infra.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
      where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {

            return _dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            
            _entities.Entry(entity).State = EntityState.Added;
            _dbset.Add(entity);
            return entity;
        }

        public virtual T Delete(T entity)
        {
            //we don´t remove the record from data base, just set it as deleted
            _entities.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public virtual void Edit(T entity)
        {
            //_entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _dbset.Update(entity);
            Save();
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
