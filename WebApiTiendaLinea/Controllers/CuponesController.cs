using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Cupones")]
    public class CuponController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarCupon([FromBody] clsCupon2 cupon)
        {
            try
            {
                bool resultado = CuponData.Registrar(cupon);
                if (resultado)
                {
                    return Ok("Cupón registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el cupón.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarCupon([FromBody] clsCupon cupon)
        {
            try
            {
                bool resultado = CuponData.Actualizar(cupon);
                if (resultado)
                {
                    return Ok("Cupón actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el cupón.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarCupon(int id)
        {
            try
            {
                bool resultado = CuponData.Eliminar(id);
                if (resultado)
                {
                    return Ok("Cupón eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el cupón.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarCupones()
        {
            try
            {
                List<clsCupon> cupones = CuponData.Listar();
                return Ok(cupones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
