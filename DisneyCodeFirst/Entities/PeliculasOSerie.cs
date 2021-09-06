using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Entities
{
    public partial class PeliculaOSerie
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Imagen { get; set; }
                
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set;}

        [Required]
        public DateTime FechaEstreno { get; set; }    
        
        [Required]
        [RegularExpression(@"^[1-5]", ErrorMessage = "no es una calificacion permitida")]
        public int Calificacion { get; set; }

        public Genero Genero { get; set; }
        public ICollection<Personaje> personaje { get; set; }

    }
}
