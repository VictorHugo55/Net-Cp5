using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;
using Challenger.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Challenger.Infrastructure.Percistence.Repositoryes
{
    public class PatioRepository : Repository<Patio>, IPatioRepository
    {
        private readonly CGContext _context;
        public PatioRepository(CGContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Patio>> GetByCidadeAsync(string cidade)
        {
            return await _context.Patios
                .Where(p => p.Cidade == cidade)
                .ToListAsync();
        }
    }
}
