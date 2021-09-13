using DisneyCodeFirst.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity:class
        where TContext: DisneyContext
    {
        private readonly TContext _disneyContext;

        protected  BaseRepository(TContext disneyContext)
        {
            _disneyContext = disneyContext;
        }
        public List<TEntity> GetAllEntities()
        {
            return _disneyContext.Set<TEntity>().ToList();
        }
        public TEntity Get(int id)
        {
            return _disneyContext.Set<TEntity>().Find(id);
        }
        public TEntity Add(TEntity entity)
        {
            _disneyContext.Set<TEntity>().Add(entity);
            _disneyContext.SaveChanges();
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            _disneyContext.Attach(entity);
            _disneyContext.Entry(entity).State = EntityState.Modified;
            _disneyContext.SaveChanges();
            return entity;
        }

        
        public void Delete(int id)
        {
            var entity = _disneyContext.Find<TEntity>(id);
            _disneyContext.Remove(entity);
            _disneyContext.SaveChanges();
            
        }
    }
  
}
