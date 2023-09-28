using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MetodoPagoController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registramarca([FromBody] clsMetodoPago metodoPago)
        {
            try
            {
                bool resultado = MetodoPago.Registrar(metodoPago);
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
        public IActionResult Actualizarmarca([FromBody] clsMetodoPago metodoPago)
        {
            try
            {
                bool resultado = MetodoPago.Actualizar(metodoPago);
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
                bool resultado = MetodoPago.Eliminar(id);
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
            List<clsMetodoPago> metodoPago = MetodoPago.Listar();
            return Ok(metodoPago);
        }
    }
}
