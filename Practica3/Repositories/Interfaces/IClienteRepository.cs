using Practica3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica3.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
        Task<bool> TieneOrdenesAsync(int clienteId);
    }
}