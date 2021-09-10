using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Repositories
{
    public class GeneroRepository : BaseRepository<Genero, MyDbContext>, IGeneroRepository
    {
        public GeneroRepository(MyDbContext dbContext) : base(dbContext) { }

        public Genero AddPersonaje(Genero genero)
        {
            return Add(genero);
        }
    }
}
