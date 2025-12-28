using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.DTOs;
using TiendaAPI.Models;
using TiendaAPI.Services;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _productoService.ObtenerTodos();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _productoService.ObtenerPorId(id);
            if(producto == null) return NotFound();

            return Ok(producto);

        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(CrearProductoDto productoDto)
        {
            var nuevoProducto = await _productoService.Crear(productoDto);
            return Ok(nuevoProducto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Producto>> EditProducto(int id, CrearProductoDto productoActu)
        {
            var producto = await _productoService.Editar(id, productoActu);
            if (producto == null) return NotFound();
            return Ok(producto);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var producto = await _productoService.Eliminar(id);
            if(!producto) return NotFound();
            return NoContent();
        }

    }
}
