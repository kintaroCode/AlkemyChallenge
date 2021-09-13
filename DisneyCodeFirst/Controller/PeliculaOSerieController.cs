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
    [Route("PeliculasOSeries")]
    public class PeliculaOSerieController : ControllerBase
    {
        private readonly IPeliculasOSeriesRepository _peliculasOSeriesRepository;

        public PeliculaOSerieController(IPeliculasOSeriesRepository peliculasOSeriesRepository)
        {
            _peliculasOSeriesRepository = peliculasOSeriesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_peliculasOSeriesRepository.GetAllEntities());
        }

        [HttpGet]
        [Route("ObtenerPelicula")]
        public IActionResult Get(int id)
        {
            var Pelicula = _peliculasOSeriesRepository.Get(id);
            if (Pelicula == null)
            {
                return BadRequest("La Pelucila no existe");
            }
            return Ok(Pelicula);
        }

        [HttpPost]
        public IActionResult Post(PeliculaOSerie peliculaOSeries)
        {
            return Ok(_peliculasOSeriesRepository.Add(peliculaOSeries));
        }

        [HttpPut]
        public IActionResult Put(PeliculaOSerie peliculaOSerie)
        {
            var internalPeliculaOSerie = _peliculasOSeriesRepository.Get(peliculaOSerie.ID);
            if (internalPeliculaOSerie == null)
            {
                return BadRequest("la pelicula no existe");
            }
                
            internalPeliculaOSerie.Imagen = peliculaOSerie.Imagen;
            internalPeliculaOSerie.Titulo = peliculaOSerie.Titulo;
            internalPeliculaOSerie.FechaEstreno = peliculaOSerie.FechaEstreno;
            internalPeliculaOSerie.Calificacion = peliculaOSerie.Calificacion;
            _peliculasOSeriesRepository.Update(internalPeliculaOSerie);
            return Ok("Elemento Actualizado");
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            
            if (_peliculasOSeriesRepository.Get(id) == null)
            {
                return BadRequest("La pelicula  no existe");
            }

            _peliculasOSeriesRepository.Delete(id);
            
            return Ok("Pelicula o serie Borrada");
        }             
    }
}
