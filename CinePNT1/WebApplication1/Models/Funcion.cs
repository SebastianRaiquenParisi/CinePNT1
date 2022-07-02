using System;
using System.ComponentModel.DataAnnotations;

namespace WebCineMVC.Models
{
    public class Funcion
    {
        public int Id { get; set; }

        
        public DateTime Fecha { get; set; }

        [Display(Name = "Sala")]
        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        [Display(Name = "Pelicula")]
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        [Display(Name = "Tickets disponibles")]
        public int TicketsDisponibles { get; set; }



    }
}
