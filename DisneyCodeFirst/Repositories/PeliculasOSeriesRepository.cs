using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Repositories
{
    public class PeliculasOSeriesRepository : BaseRepository<PeliculaOSerie, MyDbContext>, IPeliculasOSeriesRepository
    {
        public PeliculasOSeriesRepository(MyDbContext dbContext) : base(dbContext) { }

        public PeliculaOSerie AddPersonaje(PeliculaOSerie peliculaOSerie)
        {
            return Add(peliculaOSerie);
        }


    }

}
