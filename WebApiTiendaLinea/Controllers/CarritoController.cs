using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("CarritosDeCompras")]
    public class CarritoController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarCarritoDeCompras([FromBody] clsCarrito2 carrito)
        {
            try
            {
                bool resultado = Carrito.Registrar(carrito);
                if (resultado)
                {
                    return Ok("Carrito de compras registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el carrito de compras.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarCarritoDeCompras([FromBody] clsCarrito carrito)
        {
            try
            {
                bool resultado = Carrito.Actualizar(carrito);
                if (resultado)
                {
                    return Ok("Carrito de compras actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el carrito de compras.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarCarritoDeCompras(int id)
        {
            try
            {
                bool resultado = Carrito.Eliminar(id);
                if (resultado)
                {
                    return Ok("Carrito de compras eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el carrito de compras.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarCarritosDeCompras()
        {
            try
            {
                List<clsCarrito> carritos = Carrito.Listar();
                return Ok(carritos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
