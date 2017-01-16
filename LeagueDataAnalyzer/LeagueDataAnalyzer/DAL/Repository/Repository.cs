using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeagueDataAnalyzer.DAL.Repository
{
    public abstract class Repository<DatabaseContext,TEntity> : IRepository<TEntity> where TEntity : class where DatabaseContext : DbContext, new()
    {
        private DatabaseContext _entities = new DatabaseContext();
        protected DatabaseContext Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        private bool disposed = false;

        public virtual IQueryable<TEntity> GetAll()
        {

            IQueryable<TEntity> query = _entities.Set<TEntity>();
            return query;
        }

        public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = _entities.Set<TEntity>().Where(predicate);
            return query;
        }

        public virtual void Add(TEntity entity)
        {

            _entities.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {

            _entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {

            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {

            _entities.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
                if (disposing)
                    _entities.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}