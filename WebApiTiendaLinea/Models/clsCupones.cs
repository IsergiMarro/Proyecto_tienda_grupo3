namespace WebApiTiendaLinea.Models
{
    public class clsCupon
    {
        public int IdCupon { get; set; }
        public string CodigoCupon { get; set; }
        public int Descuento { get; set; }
        public string FechaVencimiento { get; set; }
        public int IdProducto { get; set; }
        public string FechaCanjeo { get; set; }
        public int IdPersona { get; set; }
        public int IdEstado { get; set; }
    }
    public class clsCupon2
    {
        public string CodigoCupon { get; set; }
        public int Descuento { get; set; }
        public string FechaVencimiento { get; set; }
        public int IdProducto { get; set; }
        public string FechaCanjeo { get; set; }
        public int IdPersona { get; set; }
        public int IdEstado { get; set; }
    }
}
