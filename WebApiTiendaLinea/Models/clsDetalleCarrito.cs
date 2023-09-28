namespace WebApiTiendaLinea.Models
{
    public class clsDetalleCarritoCompras
    {
        public int Id { get; set; }
        public int Carrito { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int Persona { get; set; }
    }
}
