using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.DTOs;
using TiendaAPI.Models;

namespace TiendaAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Producto> Crear(CrearProductoDto dto)
        {
            var nuevoProducto = _mapper.Map<Producto>(dto);
            _context.Productos.Add(nuevoProducto);
            await  _context.SaveChangesAsync();
            return nuevoProducto;
        }

        public async Task<Producto> Editar(int id, CrearProductoDto dto)
        {
            var producto = await _context.Productos.FindAsync(id);

            if(producto == null) return null;

            _mapper.Map(dto, producto);

            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> Eliminar(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if(producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Producto> ObtenerPorId(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _context.Productos.ToListAsync();
        }
    }
}
