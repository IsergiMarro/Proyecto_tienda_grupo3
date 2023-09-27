namespace WebApiTiendaLinea.Models
{
    public class clsPersona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pass { get; set; }
        public string Correo { get; set; }
        public string FechaN { get; set; }
        public int Genero { get; set; }
        public int DPI { get; set; }
        public int NIT { get; set; }
        public int TipoPersona { get; set; }
        public String Direccion { get; set; }
        public int Municipio { get; set; }
        public int Departamento { get; set; }
        public int OPC { get; set; }
        public String Error { get; set; }
    }
}
