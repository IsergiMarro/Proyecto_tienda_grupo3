using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("DetallesFacturas")]
    public class DetalleFacturaController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarDetalleFactura([FromBody] clsDetalleFactura detalleFactura)
        {
            try
            {
                bool resultado = DetalleFacturaData.Registrar(detalleFactura);
                if (resultado)
                {
                    return Ok("Detalle de factura registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el detalle de factura.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarDetalleFactura([FromBody] clsDetalleFactura detalleFactura)
        {
            try
            {
                bool resultado = DetalleFacturaData.Actualizar(detalleFactura);
                if (resultado)
                {
                    return Ok("Detalle de factura actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el detalle de factura.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarDetalleFactura(int id)
        {
            try
            {
                bool resultado = DetalleFacturaData.Eliminar(id);
                if (resultado)
                {
                    return Ok("Detalle de factura eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el detalle de factura.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarDetallesFacturas()
        {
            try
            {
                List<clsDetalleFactura> detallesFacturas = DetalleFacturaData.Listar();
                return Ok(detallesFacturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
