namespace Reserva_C.Models
{
    public class TipoSala
    {
        //- Nombre
        //- Precio
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public Sala Sala { get; set; }
    }
}
