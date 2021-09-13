using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Repositories
{
    public class PeliculasOSeriesRepository : BaseRepository<PeliculaOSerie, DisneyContext>, IPeliculasOSeriesRepository
    {
        public PeliculasOSeriesRepository(DisneyContext disneyContext) : base(disneyContext) { }

        public PeliculaOSerie AddPersonaje(PeliculaOSerie peliculaOSerie)
        {
            return Add(peliculaOSerie);
        }


    }

}
