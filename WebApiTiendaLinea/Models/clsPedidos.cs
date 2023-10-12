namespace WebApiTiendaLinea.Models
{
    public class clsPedidos
    {
        public int Id { get; set; }
        public int Persona { get; set; }
        public string Fecha_Pedido { get; set; }
        public int Total { get; set; }
        public int Estado { get; set; }
        public int Cantidad { get; set; }
        public int Detalle_carrito { get; set; }
        public int Metodo_Pago { get; set; }
       // public String Error { get; set; }
    }
    public class clsPedidos2
    {
        public int Persona { get; set; }
        public string Fecha_Pedido { get; set; }
        public int Total { get; set; }
        public int Estado { get; set; }
        public int Cantidad { get; set; }
        public int Detalle_carrito { get; set; }
        public int Metodo_Pago { get; set; }
        // public String Error { get; set; }
    }
}