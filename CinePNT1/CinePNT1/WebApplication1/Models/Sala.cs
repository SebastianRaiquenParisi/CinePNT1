
using System.ComponentModel.DataAnnotations;

namespace WebCineMVC.Models
{
    public class Sala
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un numero de sala")]
        [Range(1,20, ErrorMessage = "Numero de sala inválido")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Debe ingresar una cantidad de asientos")]
        [Range(10, 50, ErrorMessage = "Mínimo: 10 , Máximo: 50")]
        public int Asientos { get; set; }
    }
}
