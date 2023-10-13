using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;


namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {

        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistraPedidos([FromBody] clsProducto2 producto)
        {
            try
            {
                bool resultado = Productos.Registrar(producto);
                if (resultado)
                {
                    return Ok("pedido registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el pedido.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarPedidos([FromBody] clsProducto producto)
        {
            try
            {
                bool resultado = Productos.Actualizar(producto);
                if (resultado)
                {
                    return Ok("producto actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el producto.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarPedidos(int id)
        {
            try
            {
                bool resultado = Productos.Eliminar(id);
                if (resultado)
                {
                    return Ok("producto eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el producto.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Listar")]
        public IActionResult ListarPedidos()
        {
            List<clsProducto2> producto = Productos.Listar();
            return Ok(producto);
        }
    }
}
