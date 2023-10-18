using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Iniciar")]
        public IActionResult Iniciar([FromBody] clsLogin login)
        {
            bool resultado = DataLogin.login(login);
            
                return Ok(resultado);
           
        }
    }
}
