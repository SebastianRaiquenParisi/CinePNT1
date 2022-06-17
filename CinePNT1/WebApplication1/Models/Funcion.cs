using System;
namespace WebCineMVC.Models
{
    public class Funcion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Sala Sala { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
