using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasControllers : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registramarca([FromBody] clsMarca marca)
        {
            try
            {
                bool resultado = Marcas.Registrar(marca);
                if (resultado)
                {
                    return Ok("marca registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el marca.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizarmarca([FromBody] clsMarca marca)
        {
            try
            {
                bool resultado = Marcas.Actualizar(marca);
                if (resultado)
                {
                    return Ok("marca actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el marca.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult Eliminarmarca(int id)
        {
            try
            {
                bool resultado = Marcas.Eliminar(id);
                if (resultado)
                {
                    return Ok("marca eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el marca.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Listar")]
        public IActionResult Listarmarca()
        {
            List<clsMarca> marcas = Marcas.Listar();
            return Ok(marcas);
        }
    }
}
