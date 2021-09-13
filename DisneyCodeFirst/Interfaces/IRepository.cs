using System.Collections.Generic;

namespace DisneyCodeFirst.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public List<TEntity> GetAllEntities();
        public TEntity Get(int id);
        public TEntity Add(TEntity entity);
        public TEntity Update(TEntity entity );
        public void Delete(int id);

    }
}