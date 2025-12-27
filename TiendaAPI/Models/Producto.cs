using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool EsAlimento { get; set; }
    }
}
