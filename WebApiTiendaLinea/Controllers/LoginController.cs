using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Iniciar")]
        public IActionResult Iniciar([FromBody] clsLogin login)
        {
            bool resultado = false;//DataLogin.login(login);

            if (login.username == "admin" && login.password == "1234")
                resultado = true;


            return Ok(resultado);
           
        }
    }
}
