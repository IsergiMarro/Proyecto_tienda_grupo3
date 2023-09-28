using Microsoft.AspNetCore.Mvc;
using WebApiTiendaLinea.Data;
using WebApiTiendaLinea.Models;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Controllers
{
    [ApiController]
    [Route("Categoria")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarCategorias()
        {
            List<clsCategoria> categorias = CategoriaData.Listar();
            return Ok(categorias);
        }
    }
}
