using Microsoft.EntityFrameworkCore;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
{
    public abstract class GenericRepository<S, T> : IRepository<S>
        where S : class
        where T : DbContext
    {
        protected T context;

        public GenericRepository(T context)
        {
            this.context = context;
        }

        public virtual IQueryable<S> GetAll()
        {
            return context.Set<S>();
        }

        public virtual S? Get(Guid uid)
        {
            return context.Find<S>(uid);
        }

        public virtual S Add(S entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual S Edit(S entity)
        {
            context.Update(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual IEnumerable<S> Edit(IEnumerable<S> entities)
        {
            context.UpdateRange(entities);
            context.SaveChangesAsync();
            return entities;
        }

        public virtual bool Delete(S entity)
        {
            context.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public virtual void Detach(S entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }
    }
}
