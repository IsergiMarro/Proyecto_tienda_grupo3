using System;

namespace WebApiTiendaLinea.Models
{
    public class clsEnvio
    {
        public int id_envio { get; set; }
        public int id_estado { get; set; }
        public int id_persona { get; set; }
        public string direccion_envio { get; set; }
        public int id_pedido { get; set; }
    }
}
