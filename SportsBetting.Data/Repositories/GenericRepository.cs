using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SportsBetting.Models;

namespace SportsBetting.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private SportsBettingContext context;
        private IDbSet<TEntity> set;


        public GenericRepository(SportsBettingContext context)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
        }

        public IDbSet<TEntity> Set
        {
            get { return this.set; }

        }

        public virtual IEnumerable<TEntity> GetAll(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             string includeProperties = "")
        {
            IQueryable<TEntity> query = set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query;
            }
        }

        public virtual TEntity FindById(object id)
        {
            return this.set.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            this.set.Add(entity);

        }

        public virtual void Update(TEntity entity)
        {
            set.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Deleted)
            {
                set.Attach(entity);
            }

            set.Remove(entity);
        }

        public virtual void RemoveById(object id)
        {
            TEntity entityToRemove = set.Find(id);
            Remove(entityToRemove);
        }


        public TEntity ChangeState(TEntity entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
            return entity;
        }
    }
}
