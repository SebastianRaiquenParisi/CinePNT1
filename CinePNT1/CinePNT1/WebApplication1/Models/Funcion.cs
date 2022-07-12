using System;
using System.ComponentModel.DataAnnotations;
//using static WebCineMVC.Controllers.FuncionesController;

namespace WebCineMVC.Models
{
    public class Funcion
    {
        public int Id { get; set; }

        [RestrictedDate(ErrorMessage = "Fecha invalida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar una sala")]
        [Display(Name = "Sala")]
        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        [Display(Name = "Pelicula")]
        [Required(ErrorMessage = "Debe seleccionar una pelicula")]
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        [Required(ErrorMessage = "Debe ingresar por lo menos un ticket")]
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

        public void actualizarTickets(int cantidadDeTickets)
        {
            TicketsDisponibles -= cantidadDeTickets;
        }

    }
}
