using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}
