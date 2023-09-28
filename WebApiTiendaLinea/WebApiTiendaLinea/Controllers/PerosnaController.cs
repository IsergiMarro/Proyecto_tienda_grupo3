using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Persona")]
    public class PerosnaController : ControllerBase
    {
        [HttpGet]
        [Route("Listar")]
        public dynamic ListarPerosna()
        {
            List<clsPersona> persona = PersonaData.Listar();
            return persona;
        }
    }
}
