using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyCodeFirst.Entities
{
    public partial class User
    {
        [Key]
        public string UserNameId { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
