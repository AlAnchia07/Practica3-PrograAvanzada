using Microsoft.EntityFrameworkCore;
using Practica3.Data;
using Practica3.Models;
using Practica3.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica3.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Cliente>> GetAllAsync() =>
            await _context.Clientes.AsNoTracking().OrderBy(c => c.Nombre).ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id) =>
            await _context.Clientes.FindAsync(id);

        public async Task AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> TieneOrdenesAsync(int clienteId) =>
            await _context.Ordenes.AnyAsync(o => o.ClienteId == clienteId);
    }
}