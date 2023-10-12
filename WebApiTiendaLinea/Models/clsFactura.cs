using System.Globalization;

namespace WebApiTiendaLinea.Models
{
    public class clsFactura
    {
        public int id_factura { get; set; }
        public int id_persona { get; set; }
        public String fechventa { get; set; }
        public int totalVenta { get; set; }
    }
    public class clsFactura2
    {
        public int id_persona { get; set; }
        public String fechventa { get; set; }
        public int totalVenta { get; set; }
    }
}
