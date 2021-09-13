using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisneyCodeFirst.Entities
{
    
    public partial class Personaje 
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Imagen { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        
        public int Peso { get; set; }

        public int Edad { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Ha superado el limite de caracteres permitidos")]
        public string Historia { get; set; }

        public ICollection<PeliculaOSerie> PeliculaOSeries { get; set; }        
    }    
}
