using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Generos")]
    public class GeneroController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarGenero([FromBody] clsGenero2 genero)
        {
            try
            {
                bool resultado = Genero.Registrar(genero);
                if (resultado)
                {
                    return Ok("Género registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el género.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarGenero([FromBody] clsGenero genero)
        {
            try
            {
                bool resultado = Genero.Actualizar(genero);
                if (resultado)
                {
                    return Ok("Género actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el género.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarGenero(int id)
        {
            try
            {
                bool resultado = Genero.Eliminar(id);
                if (resultado)
                {
                    return Ok("Género eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el género.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarGeneros()
        {
            try
            {
                List<clsGenero> generos = Genero.Listar();
                return Ok(generos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}