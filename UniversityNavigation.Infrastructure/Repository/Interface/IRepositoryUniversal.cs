using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace UniversityNavigation.Infrastructure.Repository.Interface
{
    public interface IRepositoryUniversal<TEntity> : IDisposable where TEntity : class
    {
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        public TEntity GetByID(object id);

        public void Insert(TEntity entity);

        public void Delete(int id);

        public void Delete(TEntity entity);

        public void Update(TEntity entity);

        public void SaveChanges();
    }
}
