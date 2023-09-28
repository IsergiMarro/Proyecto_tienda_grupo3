using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;
namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosControllers : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registramunicipio([FromBody] clsMunicipio municipio)
        {
            try
            {
                bool resultado = Municipios.Registrar(municipio);
                if (resultado)
                {
                    return Ok("Municipio registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el Municipio.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizarmunicipio([FromBody] clsMunicipio municipio)
        {
            try
            {
                bool resultado = Municipios.Actualizar(municipio);
                if (resultado)
                {
                    return Ok("marca actualizado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el marca.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult Eliminarmunicipio(int id)
        {
            try
            {
                bool resultado = Municipios.Eliminar(id);
                if (resultado)
                {
                    return Ok("Municipios eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el Municipios.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Listar")]
        public IActionResult Listarmarca()
        {
            List<clsMunicipio> municipios = Municipios.Listar();
            return Ok(municipios);
        }
    }
}

