using System.ComponentModel.DataAnnotations;

namespace Practica3.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone, StringLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress, StringLength(150)]
        public string Correo { get; set; } = string.Empty;

        public ICollection<OrdenServicio> Ordenes { get; set; } = new List<OrdenServicio>();
    }
}