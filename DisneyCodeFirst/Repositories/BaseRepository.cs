using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity:class
        where TContext:DbContext
    {
        private readonly TContext _dbContext;

        protected  BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TEntity> GetAllEntities()
        {
            return _dbContext.Set<TEntity>().ToList();
        }
        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        public TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
  
}
