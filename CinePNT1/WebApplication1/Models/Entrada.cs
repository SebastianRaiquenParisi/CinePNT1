namespace WebCineMVC.Models
{
    public class Entrada
    {
        public int Id { get; set; }
        public Asiento Asiento { get; set; }
        public Comprador Comprador { get; set; }
        public Funcion Funcion { get; set; }
    }
}
