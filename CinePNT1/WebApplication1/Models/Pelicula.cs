using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

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

        [NotMapped]
        [Display(Name = "Pelicula:")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

    }
}
