using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;
using static WebApiTiendaLinea.Data.Estado;

namespace WebApiTiendaLinea.Controllers 
{
    [ApiController]
    [Route("Estados")]
    public class EstadoController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarEstado([FromBody] clsEstados2 estado)
        {
            try
            {
                bool resultado = Estado.Registrar(estado);
                if (resultado)
                {
                    return Ok("Estado registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el estado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarEstado([FromBody] clsEstados estado)
        {
            try
            {
                bool resultado = Estado.Actualizar(estado);
                if (resultado)
                {
                    return Ok("Estado actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el estado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarEstado(int id)
        {
            try
            {
                bool resultado = Estado.Eliminar(id);
                if (resultado)
                {
                    return Ok("Estado eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el estado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarEstados()
        {
            try
            {
                List<clsEstados> estados = Estado.Listar();
                return Ok(estados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}

