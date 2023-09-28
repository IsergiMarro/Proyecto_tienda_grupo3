using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {

        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistraProveedores([FromBody] clsProveedores proveedores)
        {
            try
            {
                bool resultado = Proveedores.Registrar(proveedores);
                if (resultado)
                {
                    return Ok("los proveedores se actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar los proveedores.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarProveedores([FromBody] clsProveedores proveedores)
        {
            try
            {
                bool resultado = Proveedores.ActualizarProveedores(proveedores);
                if (resultado)
                {
                    return Ok("los proveedores se actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar los proveedores.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarProveedores(int id)
        {
            try
            {
                bool resultado = Proveedores.Eliminar(id);
                if (resultado)
                {
                    return Ok("proveedor fur eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el proveedor.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Listar")]
        public IActionResult ListarProveedores()
        {
            List<clsProveedores> proveedores = Proveedores.Listar();
            return Ok(proveedores);
        }
    }
}
