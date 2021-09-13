using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Repositories
{
    public class GeneroRepository : BaseRepository<Genero, DisneyContext>, IGeneroRepository
    {
        public GeneroRepository(DisneyContext disneyContext) : base(disneyContext) { }

        public Genero AddPersonaje(Genero genero)
        {
            return Add(genero);
        }
    }
}
