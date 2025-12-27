using AutoMapper;
using TiendaAPI.DTOs;
using TiendaAPI.Models;

namespace TiendaAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CrearProductoDto, Producto>();
        }
    }
}
