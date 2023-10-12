using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrtipo_personas([FromBody] clsDepartamento2 departamento)
        {
            try
            {
                bool resultado = Departamentos.Registrar(departamento);
                if (resultado)
                {
                    return Ok("EL Departamento se ha registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el departmaneto");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizartipo_personas([FromBody] clsDepartamento departamento)
        {
            try
            {
                bool resultado = Departamentos.Actualizar(departamento);
                if (resultado)
                {
                    return Ok("EL departamento se actualizo exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el departamento.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult Eliminartipo_personas(int id)
        {
            try
            {
                bool resultado = Departamentos.Eliminar(id);
                if (resultado)
                {
                    return Ok("Departamento eliminado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar el departamento.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Listar")]
        public IActionResult Listartipo_personas()
        {
            List<clsDepartamento> departamentos = Departamentos.Listar();
            return Ok(departamentos);
        }
    }
}