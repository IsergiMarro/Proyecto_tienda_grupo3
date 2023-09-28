using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        [HttpGet("Listar")]
        public IActionResult ListarPersona()
        {
            List<clsPersona> personas = PersonaData.Listar();
            return Ok(personas);
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarPersona([FromBody] clsPersona persona)
        {
            if (persona == null)
            {
                return BadRequest("Los datos de la persona son nulos.");
            }

            bool resultado = PersonaData.Insertar(persona);

            if (resultado)
            {
                return Ok("Persona insertada correctamente.");
            }
            else
            {
                return StatusCode(500, "No se pudo insertar la persona.");
            }
        }
    }
}