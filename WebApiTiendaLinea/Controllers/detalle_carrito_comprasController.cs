using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("DetalleCarritoCompras")]
    public class DetalleCarritoComprasController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarDetalleCarritoCompras([FromBody] clsDetalleCarritoCompras detalleCarrito)
        {
            try
            {
                bool resultado = DetalleCarritoComprasData.Registrar(detalleCarrito);
                if (resultado)
                {
                    return Ok("Detalle del carrito de compras registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el detalle del carrito de compras.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarDetalleCarritoCompras([FromBody] clsDetalleCarritoCompras detalleCarrito)
        {
            try
            {
                bool resultado = DetalleCarritoComprasData.Actualizar(detalleCarrito);
                if (resultado)
                {
                    return Ok("Detalle del carrito de compras actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el detalle del carrito de compras.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarDetalleCarritoCompras(int id)
        {
            try
            {
                bool resultado = DetalleCarritoComprasData.Eliminar(id);
                if (resultado)
                {
                    return Ok("Detalle del carrito de compras eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el detalle del carrito de compras.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarDetalleCarritoCompras()
        {
            try
            {
                List<clsDetalleCarritoCompras> detallesCarrito = DetalleCarritoComprasData.Listar();
                return Ok(detallesCarrito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
