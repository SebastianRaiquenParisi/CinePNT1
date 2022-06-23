using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCineMVC.Models;

namespace WebCineMVC
{
    //Esta clase es la conexión a DB que usara EntityFramework, + otras cosas
    // como el manejo de las clases de negocio a las Table de DB
    public class CineContext : DbContext
    {
        public CineContext(DbContextOptions<CineContext> options) : base(options)
        {

        }

        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-G267I84\SQLEXPRESS;Database=CinePNT;Trusted_Connection=True");
        }*/
    }


}
