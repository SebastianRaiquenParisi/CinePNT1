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
    internal class CineContext : DbContext
    {
        public DbSet<Complejo> Complejos { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Comprador> Compradores { get; set; }
        public DbSet<Asiento> Asientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GE740DJ;Database=CinePNT;Trusted_Connection=True");
        }
    }


}
