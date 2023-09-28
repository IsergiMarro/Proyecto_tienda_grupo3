using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Facturas")]
    public class FacturaController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarFactura([FromBody] clsFactura factura)
        {
            try
            {
                bool resultado = FacturaData.Registrar(factura);
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
        public IActionResult ActualizarFactura([FromBody] clsFactura factura)
        {
            try
            {
                bool resultado = FacturaData.Actualizar(factura);
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
                bool resultado = FacturaData.Eliminar(id);
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
                List<clsFactura> facturas = FacturaData.Listar();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
