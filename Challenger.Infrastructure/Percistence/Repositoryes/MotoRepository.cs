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
    internal class MotoRepository : Repository<Moto>, IMotoRepository
    {
        private readonly CGContext _context;

        public MotoRepository(CGContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Moto?> GetByPlacaAsync(string placa)
        {
            return await _context.Motos
                .FirstOrDefaultAsync(m => m.Placa.Valor == placa);
        }
    }
}
