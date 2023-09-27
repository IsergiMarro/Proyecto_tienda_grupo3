namespace WebApiTiendaLinea.Models
{
    public class clsDetalleFactura
    {
        public int Id { get; set; }
        public string Descripcion { get; set;}
        public int Factura { get; set;}
        public int MetodoP { get; set;}
        public int Pedido { get; set;}
    }
}
