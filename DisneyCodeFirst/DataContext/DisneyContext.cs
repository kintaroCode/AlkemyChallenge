using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisneyCodeFirst.Entities;

namespace DisneyCodeFirst.DataContext
{
    public partial class MyDbContext : DbContext
    {       
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Personaje> Personaje { get; set; }
        public DbSet<PeliculaOSerie> PeliculaOSerie { get; set; }
        public DbSet<Genero> Genero { get; set; }        
        public DbSet<User> User { get; set; }

    }
}
