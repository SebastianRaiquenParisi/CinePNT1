using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebCineMVC.Models
{
    public class Compra
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Debe completar el DNI")]
        [RegularExpression("^[\\s\\S]{7,8}$", ErrorMessage = " El número de DNI no es válido.")]
        public String Dni { get; set; }
        
        [Required(ErrorMessage = "Debe elegir una función")]
        public int FuncionId { get; set; }
     
        public Funcion Funcion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar al menos una entrada")]
        [Range(1,999,ErrorMessage = "Cantidad inválida")]
        public int CantidadDeEntradas { get; set; }

    }
        
}
