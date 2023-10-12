using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {

        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistraPedidos([FromBody] clsPedidos2 pedidos)
        {
            try
            {
                bool resultado = Pedidos.Registrar(pedidos);
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
        public IActionResult ActualizarPedidos([FromBody] clsPedidos pedidos)
        {
            try
            {
                if (pedidos == null || pedidos.Id <= 0)
                {
                    return BadRequest("Datos de pedido no válidos.");
                }

                bool resultado = Pedidos.Actualizar(pedidos);
                if (resultado)
                {
                    return Ok("Pedido actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el pedido.");
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
                if (id <= 0)
                {
                    return BadRequest("ID de pedido no válido.");
                }

                bool resultado = Pedidos.Eliminar(id);
                if (resultado)
                {
                    return Ok("Pedido eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el pedido.");
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
            List<clsPedidos> pedidos = Pedidos.Listar();
            return Ok(pedidos);
        }
    }
}