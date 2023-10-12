using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("CategoriasProductos")]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        [Route("Registrar")]
        public IActionResult RegistrarCategoriaProducto([FromBody] clsCategoria2 categoriaProducto)
        {
            try
            {
                bool resultado = Categoria.Registrar(categoriaProducto);
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
        [Route("Actualizar")]
        public IActionResult ActualizarCategoriaProducto( [FromBody] clsCategoria categoriaProducto)
        {
            try
            {
                bool resultado = Categoria.Actualizar(categoriaProducto);
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
        [Route("Eliminar/{id}")]
        public IActionResult EliminarCategoriaProducto(int id)
        {
            try
            {
                bool resultado = Categoria.Eliminar(id);
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
        [Route("Listar")]
        public IActionResult ListarCategoriasProductos()
        {
            try
            {
                List<clsCategoria> categoriasProductos = Categoria.Listar();
                return Ok(categoriasProductos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}