using System.ComponentModel.DataAnnotations;

namespace WebCineMVC.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar nombre de pelicula")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar una duración")]
        [Range(1,300, ErrorMessage = "Error, rango de duración en minutos: 1-300")]
        public double Duracion { get; set; }

        //public List<Funcion> Funciones { get; set; }
    }
}
