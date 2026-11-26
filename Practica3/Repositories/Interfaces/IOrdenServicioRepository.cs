using Practica3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica3.Repositories.Interfaces
{
    public interface IOrdenServicioRepository
    {
        Task<IEnumerable<OrdenServicio>> GetAllAsync(EstadoOrden? estado = null);
        Task<OrdenServicio?> GetByIdAsync(int id);
        Task AddAsync(OrdenServicio orden);
        Task UpdateAsync(OrdenServicio orden);
        Task DeleteAsync(OrdenServicio orden);
    }
}