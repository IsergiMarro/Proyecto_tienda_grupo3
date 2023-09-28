using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Departamentos")]
    public class DepartamentoController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarDepartamento([FromBody] clsDepartamento departamento)
        {
            try
            {
                bool resultado = DepartamentoData.Registrar(departamento);
                if (resultado)
                {
                    return Ok("Departamento registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar el departamento.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarDepartamento([FromBody] clsDepartamento departamento)
        {
            try
            {
                bool resultado = DepartamentoData.Actualizar(departamento);
                if (resultado)
                {
                    return Ok("Departamento actualizado exitosamente.");
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
        public IActionResult EliminarDepartamento(int id)
        {
            try
            {
                bool resultado = DepartamentoData.Eliminar(id);
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

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarDepartamentos()
        {
            try
            {
                List<clsDepartamento> departamentos = DepartamentoData.Listar();
                return Ok(departamentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
