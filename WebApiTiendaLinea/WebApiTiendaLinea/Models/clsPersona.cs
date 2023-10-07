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
        public int id_Genero { get; set; }
        public string Genero { get; set; }
        public int DPI { get; set; }
        public int NIT { get; set; }
        public int TipoPersona { get; set; }
        public string Rol { get; set; }
        public string Direccion { get; set; }
        public int id_municipio { get; set; }
        public string Municipio { get; set; }
        public int id_departamento { get; set; }
        public string Departamento { get; set; }
        public int OPC { get; set; }
        public string Error { get; set; }
    }
}
