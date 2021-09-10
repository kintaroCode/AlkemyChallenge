using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Repositories
{
    public class PersonajeRepository : BaseRepository<Personaje, MyDbContext>, IPersonajeRepository
    {
        public PersonajeRepository(MyDbContext dbContext) : base(dbContext) { }

        public Personaje AddPersonaje(Personaje personaje)
        {
            return Add(personaje);            
        }


    }
}
