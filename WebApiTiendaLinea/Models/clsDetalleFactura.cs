namespace WebApiTiendaLinea.Models
{
    public class clsDetalleFactura
    {
        public int id_detalle_facturas { get; set; }
        public int ID_factura { get; set; }
        public int ID_prducto { get; set; }
        public int CANTIDAD { get; set; }
        public int ID_metodo_pago { get; set; }
        public int ID_pedido { get; set; }
        public int PRECIO_unitario { get; set; }
        public int PRECIO_linea { get; set; }
    }
    public class clsDetalleFactura2
    {
        public int ID_factura { get; set;  }
        public int ID_prducto{ get; set; }
        public int CANTIDAD { get; set; }
        public int ID_metodo_pago { get; set; }
        public int ID_pedido { get; set; }
        public int PRECIO_unitario { get; set; }
        public int PRECIO_linea { get; set; }


    }
}

