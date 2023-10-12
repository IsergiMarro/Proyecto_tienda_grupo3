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

        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistraPersona([FromBody] clsPersona2 persona)
        {
            try
            {
                bool resultado = PersonaData.Registrar(persona);
                if (resultado)
                {
                    return Ok("la persona se Registro exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar la persona.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarCupon([FromBody] clsPersona persona)
        {
            try
            {
                bool resultado = PersonaData.Actualizar(persona);
                if (resultado)
                {
                    return Ok("la persona se a actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar la persona.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarCupon(int id)
        {
            try
            {
                bool resultado = PersonaData.Eliminar(id);
                if (resultado)
                {
                    return Ok("persona eliminada exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar la persona.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Listar")]
        public IActionResult ListarPersona()
        {
            try
            {
                List<clsPersona> personas = PersonaData.Listar();
            return Ok(personas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


    }
}


