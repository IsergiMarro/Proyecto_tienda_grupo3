using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Envio")]
    public class EnvioController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarEnvio([FromBody] clsEnvio envio)
        {
            try
            {
                bool resultado = EnvioData.Registrar(envio);
                if (resultado)
                {
                    return Ok("Envío registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el envío.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarEnvio([FromBody] clsEnvio envio)
        {
            try
            {
                bool resultado = EnvioData.Actualizar(envio);
                if (resultado)
                {
                    return Ok("Envío actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el envío.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarEnvio(int id)
        {
            try
            {
                bool resultado = EnvioData.Eliminar(id);
                if (resultado)
                {
                    return Ok("Envío eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el envío.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarEnvios()
        {
            try
            {
                List<clsEnvio> envios = EnvioData.Listar();
                return Ok(envios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
