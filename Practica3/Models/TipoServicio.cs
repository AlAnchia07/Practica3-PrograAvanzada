using System.ComponentModel.DataAnnotations;

namespace Practica3.Models
{
    public class TipoServicio
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<OrdenServicio> Ordenes { get; set; } = new List<OrdenServicio>();
    }
}