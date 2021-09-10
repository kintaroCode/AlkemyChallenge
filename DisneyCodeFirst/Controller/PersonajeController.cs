using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Controller
{
    [ApiController]
    [Route("/[controller]")]
    public class PersonajeController : ControllerBase
    {
        private readonly DisneyContext _myDbContext;

        public PersonajeController(DisneyContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_myDbContext.Personaje.ToList());
        }
        
        [HttpPost]
        public IActionResult Post(Personaje personaje)
        {
            _myDbContext.Personaje.Add(personaje);
            _myDbContext.SaveChanges();
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Put(Personaje personaje)
        {
            if (_myDbContext.Personaje.FirstOrDefault(x=> x.ID ==personaje.ID)==null)
            {
                return BadRequest("el personaje no existe");
            }

            var InternalPersonaje = _myDbContext.Personaje.Find(personaje.ID);
            InternalPersonaje.Nombre = personaje.Nombre;
            InternalPersonaje.Historia = personaje.Historia;
            _myDbContext.SaveChanges();

            return Ok(_myDbContext.Personaje.ToList());
        }
        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_myDbContext.Personaje.FirstOrDefault(x=>x.ID==id )==null)
            {
                return BadRequest("el personbaje no existe");
            }
            var aux = _myDbContext.Personaje.Find(id);
            _myDbContext.Personaje.Remove(aux);
            _myDbContext.SaveChanges();
            return Ok("Personaje Borrado");
        }        
    }
}
