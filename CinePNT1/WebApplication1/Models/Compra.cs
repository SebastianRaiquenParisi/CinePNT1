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

        public String Dni { get; set; }

        public int FuncionId { get; set; }
        public Funcion Funcion { get; set; }

        public int CantidadDeEntradas { get; set; }

    }
        
}
