using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using DisneyCodeFirst.Repositories;
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
        private readonly IPersonajeRepository _personajeRepository;

        public PersonajeController(IPersonajeRepository personajeRepository)
        {
            _personajeRepository = personajeRepository;
        }
      
        [HttpGet]

        public IActionResult Get()
        {
            var personajes = _personajeRepository.GetAllEntities().Select( x => new { x.Imagen, x.Nombre } );            
            return Ok(personajes);
        }
       
        [HttpGet]
        [Route("obtenerPersonaje")]
        public IActionResult Get(int id)
        {
            var personaje = _personajeRepository.Get(id);
            if (personaje==null)
            {
                return BadRequest("El personaje no existe");
            }
            return Ok(personaje);
        }

        [HttpGet]
        public IActionResult Get(string nombre, int edad, int peso, int IdMovie)
        {
            var personaje = new Personaje();
            var ListPersonaje = _personajeRepository.GetAllEntities();

            if (!string.IsNullOrEmpty(nombre))
            {
                ListPersonaje = ListPersonaje.Where(x => x.Nombre == nombre).ToList();
            }
            if (edad !=0)
            {
                ListPersonaje = ListPersonaje.Where(x => x.Edad == edad).ToList();
            }
            if (peso != 0)
            {
                ListPersonaje = ListPersonaje.Where(x => x.Peso == peso).ToList();
            }
            if (IdMovie != 0)
            {
                ListPersonaje = ListPersonaje.Where(x => x.PeliculaOSeries.Where(y => y.ID==IdMovie)==IdMovie).toList();
            }
            {

            }
            else()
        }
    
        [HttpPost]
        public IActionResult Post(Personaje personaje)
        {
            _personajeRepository.Add(personaje);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Put(Personaje personaje)
        {
            var InternalPersonaje = _personajeRepository.Get(personaje.ID);
            if (_personajeRepository.Get(personaje.ID)==null)
            {
                return BadRequest("el personaje no existe");
            }
            
            InternalPersonaje.Nombre = personaje.Nombre;
            InternalPersonaje.Historia = personaje.Historia;
            _personajeRepository.Update(InternalPersonaje);

            return Ok(InternalPersonaje);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_personajeRepository.Get(id)==null)
            {
                return BadRequest("el personaje no existe");
            }
            _personajeRepository.Delete(id);
            return Ok("Personaje Borrado");
        }        
    }
}
