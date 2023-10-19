using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Comentarios")]
    public class ComentarioController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarComentario([FromBody] clsComentarios comentario)
        {
            try
            {
                bool resultado = Comentarios.Registrar(comentario);
                if (resultado)
                {
                    return Ok("Comentario registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el comentario.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarComentario([FromBody] clsComentarios3 comentario)
        {
            try
            {
                bool resultado = Comentarios.Actualizar(comentario);
                if (resultado)
                {
                    return Ok("Comentario actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el comentario.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarComentario(int id)
        {
            try
            {
                bool resultado = Comentarios.Eliminar(id);
                if (resultado)
                {
                    return Ok("Comentario eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el comentario.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarComentarios()
        {
            try
            {
                List<clsComentarios2> comentarios = Comentarios.Listar();
                return Ok(comentarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
