using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.DTOs
{
    public class CrearProductoDto
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [Range(0.01, 9999, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }
        public bool EsAlimento { get; set; }
    }
}
