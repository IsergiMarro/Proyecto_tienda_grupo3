namespace WebApiTiendaLinea.Models
{
    public class clsDetalleCarrito
    {
        public int Id { get; set; }
        public int Carrito { get; set;}
        public int Producto { get; set;}
        public int Cantidad { get; set;}
        public float SubTotal { get;}
        public float Total { get; set; }
        public int Persona { get; set;}
    }
}
