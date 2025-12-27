using TiendaAPI.DTOs;
using TiendaAPI.Models;

namespace TiendaAPI.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerTodos();
        Task<Producto> ObtenerPorId(int id);
        Task<Producto> Crear(CrearProductoDto dto);
        Task<bool> Eliminar (int id);
        Task<Producto> Editar(int id, CrearProductoDto dto);
    }
}
