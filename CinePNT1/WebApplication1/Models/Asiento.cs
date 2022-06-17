using System.ComponentModel.DataAnnotations.Schema;
namespace WebCineMVC.Models
{
    public class Asiento
    {
        public int Id { get; set; }
        public int Fila { get; set; }
        public int Numero { get; set; }

        [ForeignKey("Entrada")]
        public int IdEntrada { get; set; }
    }
}
