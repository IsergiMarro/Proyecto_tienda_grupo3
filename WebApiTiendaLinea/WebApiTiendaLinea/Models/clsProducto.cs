namespace WebApiTiendaLinea.Models
{
    public class clsProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set;}
        public int Stock { get; set;}
        public int Proveedor { get; set;}
        public int Categoria { get; set;}
        public int Marca { get; set;}
        public String Imagen { get; set;}

        public String Error { get; set; }
    }
}
