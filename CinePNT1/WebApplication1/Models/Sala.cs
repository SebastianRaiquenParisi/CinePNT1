
namespace WebCineMVC.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Complejo Complejo { get; set; }
    }
}
