using Practica3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica3.Repositories.Interfaces
{
    public interface ITipoServicioRepository
    {
        Task<IEnumerable<TipoServicio>> GetAllAsync();
        Task<TipoServicio?> GetByIdAsync(int id);
    }
}