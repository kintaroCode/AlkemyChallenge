using System.Collections.Generic;

namespace DisneyCodeFirst.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public List<TEntity> GetAllEntities();
        public TEntity Get(TEntity);
        public TEntity Add();
        public TEntity Update();
        public TEntity Delete();

    }
}