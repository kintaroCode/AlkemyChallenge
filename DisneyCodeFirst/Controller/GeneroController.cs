using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Controller 
{
    [ApiController]
    [Route("{Controller}")]
    public class GeneroController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;

        public GeneroController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_myDbContext.Genero.ToList());
        }

        [HttpPost]
        public IActionResult Post(Genero genero)
        {
            return Ok(_myDbContext.Genero.Add(genero));
        }

        [HttpPut]
        public IActionResult Put(Genero genero)
        {
            if (_myDbContext.Genero.FirstOrDefault(x => x.ID ==genero.ID) == null)
            {
                return BadRequest("el personaje no existe");
            }
            var internalGenero = _myDbContext.Genero.Find(genero.ID);
            internalGenero.imagen = genero.imagen;
            internalGenero.NombreGenero = genero.NombreGenero;
            _myDbContext.SaveChanges();
            return Ok("Elemento Actualizado");
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_myDbContext.PeliculaOSerie.FirstOrDefault(x => x.ID == id) == null)
            {
                return BadRequest("El genero no existe");
            }
            var aux = _myDbContext.Genero.Find(id);
            _myDbContext.Genero.Remove(aux);
            _myDbContext.SaveChanges();
            return Ok("Genero Borrado");
        }
    }
}
}
