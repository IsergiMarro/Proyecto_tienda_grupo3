using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class Tipo_personasController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrtipo_personas([FromBody] clsTipo_personas2 tipo_personas)
        {
            try
            {
                bool resultado = Tipo_personas.Registrar(tipo_personas);
                if (resultado)
                {
                    return Ok("EL tipo_personas se registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el marca el tipo_personas");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizartipo_personas([FromBody] clsTipo_personas tipo_personas)
        {
            try
            {
                bool resultado = Tipo_personas.Actualizar(tipo_personas);
                if (resultado)
                {
                    return Ok("EL tipo_personas se actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el tipo_personas.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult Eliminartipo_personas(int id)
        {
            try
            {
                bool resultado = Tipo_personas.Eliminar(id);
                if (resultado)
                {
                    return Ok("tipo_personas eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el tipo_personas.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Listar")]
        public IActionResult Listartipo_personas()
        {
            List<clsTipo_personas> tipo_personas = Tipo_personas.Listar();
            return Ok(tipo_personas);
        }
    }
}
