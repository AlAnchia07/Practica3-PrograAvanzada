using Microsoft.EntityFrameworkCore;
using Practica3.Data;
using Practica3.Models;
using Practica3.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica3.Repositories
{
    public class TipoServicioRepository : ITipoServicioRepository
    {
        private readonly ApplicationDbContext _context;
        public TipoServicioRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<TipoServicio>> GetAllAsync() =>
            await _context.TiposServicio.AsNoTracking().OrderBy(t => t.Nombre).ToListAsync();

        public async Task<TipoServicio?> GetByIdAsync(int id) =>
            await _context.TiposServicio.FindAsync(id);
    }
}