using Microsoft.EntityFrameworkCore;
using Practica3.Data;
using Practica3.Models;
using Practica3.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica3.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly ApplicationDbContext _context;
        public OrdenServicioRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<OrdenServicio>> GetAllAsync(EstadoOrden? estado = null)
        {
            var query = _context.Ordenes
                .Include(o => o.Cliente)
                .Include(o => o.TipoServicio)
                .AsNoTracking();

            if (estado.HasValue)
                query = query.Where(o => o.Estado == estado.Value);

            return await query.OrderByDescending(o => o.FechaIngreso).ToListAsync();
        }

        public async Task<OrdenServicio?> GetByIdAsync(int id) =>
            await _context.Ordenes
                .Include(o => o.Cliente)
                .Include(o => o.TipoServicio)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(OrdenServicio orden)
        {
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrdenServicio orden)
        {
            _context.Ordenes.Update(orden);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrdenServicio orden)
        {
            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();
        }
    }
}