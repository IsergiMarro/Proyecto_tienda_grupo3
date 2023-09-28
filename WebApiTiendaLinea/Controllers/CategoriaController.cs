using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("api/categoriaProductos")]
    public class CategoriaProductosController : ControllerBase
    {
        [HttpPost]
        [Route("registrar")]
        public IActionResult RegistrarCategoriaProducto([FromBody] CategoriaProductos categoriaProducto)
        {
            try
            {
                bool resultado = CategoriaProductosData.Registrar(categoriaProducto);
                if (resultado)
                {
                    return Ok("Categoría de producto registrada exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar la categoría de producto.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("actualizar")]
        public IActionResult ActualizarCategoriaProducto([FromBody] CategoriaProductos categoriaProducto)
        {
            try
            {
                bool resultado = CategoriaProductosData.Actualizar(categoriaProducto);
                if (resultado)
                {
                    return Ok("Categoría de producto actualizada exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar la categoría de producto.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarCategoriaProducto(int id)
        {
            try
            {
                bool resultado = CategoriaProductosData.Eliminar(id);
                if (resultado)
                {
                    return Ok("Categoría de producto eliminada exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo eliminar la categoría de producto.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListarCategoriasProductos()
        {
            try
            {
                List<CategoriaProductos> categoriasProductos = CategoriaProductosData.Listar();
                return Ok(categoriasProductos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
