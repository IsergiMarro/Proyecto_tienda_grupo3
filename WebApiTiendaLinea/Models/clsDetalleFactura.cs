using System;

namespace WebApiTiendaLinea.Models
{
    public class clsDetalleFactura
    {
        public int id_detalle_facturas { get; set; }
        public string descripcion { get; set; }
        public int id_factura { get; set; }
        public int id_metodo_pago { get; set; }
        public int id_pedido { get; set; }
    }
}
