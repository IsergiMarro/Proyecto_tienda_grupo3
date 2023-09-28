namespace WebApiTiendaLinea.Models
{
    public class clsCupon
    {
        public int IdCupon { get; set; }
        public string CodigoCupon { get; set; }
        public int Descuento { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaCanjeo { get; set; }
        public int IdPersona { get; set; }
        public int IdEstado { get; set; }
    }
}
