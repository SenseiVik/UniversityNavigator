using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UniversityNavigation.Infrastructure.Repository.Interface;

namespace UniversityNavigation.Infrastructure.Repository.Implementation
{
    public abstract class BaseUniversalRepository<TEntity> : IRepositoryUniversal<TEntity> where TEntity : class
    {
        protected DbContext dbContext;
        protected DbSet<TEntity> dbSet;

        public BaseUniversalRepository(DbContext context)
        {
            this.dbContext = context;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (this.dbContext.Entry(entity).State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            this.dbSet.Remove(entity);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = this.dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public TEntity GetByID(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Attach(entity);
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            this.dbContext?.Dispose();
        }
    }
}
