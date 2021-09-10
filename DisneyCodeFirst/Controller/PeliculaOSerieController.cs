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
    [Route("PeliculasOSeries")]
    public class PeliculaOSerieController : ControllerBase
    {
        private readonly DisneyContext _myDbContext;

        public PeliculaOSerieController(DisneyContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_myDbContext.PeliculaOSerie.ToList());
        }

        [HttpPost]
        public IActionResult Post(PeliculaOSerie peliculaOSerie)
        {
            return Ok(_myDbContext.PeliculaOSerie.Add(peliculaOSerie));
        }

        [HttpPut]
        public IActionResult Put(PeliculaOSerie peliculaOSerie)
        {
            if (_myDbContext.PeliculaOSerie.FirstOrDefault(x => x.ID == peliculaOSerie.ID) == null)
            {
                return BadRequest("el personaje no existe");
            }
            var internalPeliculaOSerie = _myDbContext.PeliculaOSerie.Find(peliculaOSerie.ID);            internalPeliculaOSerie.Imagen = peliculaOSerie.Imagen;
            internalPeliculaOSerie.Titulo = peliculaOSerie.Titulo;
            internalPeliculaOSerie.FechaEstreno = peliculaOSerie.FechaEstreno;
            internalPeliculaOSerie.Calificacion = peliculaOSerie.Calificacion;
            _myDbContext.SaveChanges();
            return Ok("Elemento Actualizado");
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_myDbContext.PeliculaOSerie.FirstOrDefault(x => x.ID == id) == null)
            {
                return BadRequest("La pelicula  no existe");
            }
            var aux = _myDbContext.PeliculaOSerie.Find(id);
            _myDbContext.PeliculaOSerie.Remove(aux);
            _myDbContext.SaveChanges();
            return Ok("Personaje Borrado");
        }             
    }
}
