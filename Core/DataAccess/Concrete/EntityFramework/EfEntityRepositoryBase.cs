using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {

        public void Add(TEntity entity)
        {
           using (TContext context = new TContext())
            {
              //var addedEntity =   context.Entry(entity); // eklenen entity
              //  addedEntity.State = EntityState.Added;
                
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
              
                context.Remove(entity);
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {

                return context.Set<TEntity>()
                              .SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (TContext context = new TContext())
            {

                return filter == null ? context.Set<TEntity>().ToList():
                                        context.Set<TEntity>().Where(filter).ToList();

                //return context.Set<TEntity>().Where(filter ?? (x => true)).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                context.Update(entity);
                context.SaveChanges();

            }
        }
    }
}
