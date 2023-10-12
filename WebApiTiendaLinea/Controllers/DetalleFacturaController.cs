using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("DetalleFacturaController")]
    public class DetalleFacturaController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarFactura([FromBody] clsDetalleFactura2 detallefacturas)
        {
            try
            {
                bool resultado = DetalleFactura.Registrar(detallefacturas);
                if (resultado)
                {
                    return Ok("Factura registrada exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar la factura.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarFactura([FromBody] clsDetalleFactura detallefacturas)
        {
            try
            {
                bool resultado = DetalleFactura.Actualizar(detallefacturas);
                if (resultado)
                {
                    return Ok("Factura actualizada exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar la factura.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarFactura(int id)
        {
            try
            {
                bool resultado = DetalleFactura.Eliminar(id);
                if (resultado)
                {
                    return Ok("Factura eliminada exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar la factura.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarFacturas()
        {
            try
            {
                List<clsDetalleFactura> detallefacturas = DetalleFactura.Listar();
                return Ok(detallefacturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}