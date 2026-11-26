using System.ComponentModel.DataAnnotations;

namespace Practica3.Models
{
    public class OrdenServicio
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Equipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción del problema es obligatoria")]
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a cero")]
        public decimal CostoEstimado { get; set; }

        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEntrega { get; set; }

        public EstadoOrden Estado { get; set; } = EstadoOrden.Pendiente;

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int TipoServicioId { get; set; }
        public TipoServicio? TipoServicio { get; set; }
    }
}