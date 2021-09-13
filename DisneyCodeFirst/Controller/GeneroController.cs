using DisneyCodeFirst.DataContext;
using DisneyCodeFirst.Entities;
using DisneyCodeFirst.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Controller 
{
    [ApiController]
    [Route("Genero")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok(_generoRepository.GetAllEntities());
        }
        [HttpGet]
        [Route("ObtenerGenero")]
        public IActionResult Get(int Id)
        {
            var genero = _generoRepository.Get(Id);
            if (genero==null)
            {
                return BadRequest("No existe el Genero");
            }

            return Ok(genero);
        }
        [HttpPost]
        public IActionResult Post(Genero genero)
        {
            return Ok(_generoRepository.Add(genero));
        }

        [HttpPut]
        public IActionResult Put(Genero genero)
        {
            var internalGenero = _generoRepository.Get(genero.ID);
            if (internalGenero == null)
            {
                return BadRequest("el personaje no existe");
            }
            
            internalGenero.imagen = genero.imagen;
            internalGenero.NombreGenero = genero.NombreGenero;
            _generoRepository.Update(internalGenero);
            return Ok("Elemento Actualizado");
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {

            if (_generoRepository.Get(id) == null)
            {
                return BadRequest("El genero no existe");
            }
            _generoRepository.Delete(id);
            return Ok("Genero Borrado");
        }
    }
}

