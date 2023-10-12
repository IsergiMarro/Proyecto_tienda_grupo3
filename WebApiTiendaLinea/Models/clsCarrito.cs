namespace WebApiTiendaLinea.Models
{
    public class clsCarrito
    {
        public int id_carrito_compras { get; set; }
        public int id_persona { get; set; }
        public int id_detalle_carrito_compras { get; set; }
    }
    public class clsCarrito2
    {
        public int id_persona { get; set; }
        public int id_detalle_carrito_compras { get; set; }
    }
}
