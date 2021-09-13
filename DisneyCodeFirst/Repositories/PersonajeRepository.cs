using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Repositories
{
    public class PersonajeRepository : BaseRepository<Personaje, DisneyContext>, IPersonajeRepository
    {
        public PersonajeRepository(DisneyContext disneyContext) : base(disneyContext) { }

        public Personaje AddPersonaje(Personaje personaje)
        {
            return Add(personaje);            
        }


    }
}
