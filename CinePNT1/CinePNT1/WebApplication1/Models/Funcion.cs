using System;
using System.ComponentModel.DataAnnotations;
//using static WebCineMVC.Controllers.FuncionesController;

namespace WebCineMVC.Models
{
    public class Funcion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha")]
        [RestrictedDate(ErrorMessage = "Fecha invalida")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Sala")]
        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        [Display(Name = "Pelicula")]
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        [Display(Name = "Tickets disponibles")]
        public int TicketsDisponibles { get; set; }

        public class RestrictedDate : ValidationAttribute
        {
            public override bool IsValid(object date)
            {
                DateTime fecha = (DateTime)date;
                return fecha >= DateTime.Now;
            }
        }

        public void actualizarTickets(int cantidadDeTickets) {
            TicketsDisponibles -= cantidadDeTickets;
        }

        public String getPelicula() {
            return Pelicula.Nombre.ToString();
        }

    }
}
