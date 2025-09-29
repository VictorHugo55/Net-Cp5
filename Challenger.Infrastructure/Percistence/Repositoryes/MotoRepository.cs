using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenger.Application.DTOs.Requests;
using Challenger.Application.pagination;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;
using Challenger.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Challenger.Infrastructure.Percistence.Repositoryes
{
    public class MotoRepository : Repository<Moto>, IMotoRepository
    {
        private readonly CGContext _context;
        private IMotoRepository _motoRepositoryImplementation;

        public MotoRepository(CGContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Moto?> GetByPlacaAsync(string placa)
        {
            return await _context.Motos
                .FirstOrDefaultAsync(m => m.Placa.Valor == placa);
        }

        public async Task<PaginatedResult<MotoSummary>> GetPageAsync(PageRequest page, MotoQuery? filter = null, CancellationToken ct = default)
        {
            page.EnsureValid();
            
            IQueryable<Moto> query = _context.Motos.AsNoTracking();
            if (filter is not null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Placa))
                {
                    var placa = filter.Placa.Trim();
                    query = query.Where(m => m.Placa.Valor.Contains(placa));
                }
                if (filter.FromCreatedAtUc is not null)
                    query = query.Where(m => m.CreatedAt == filter.FromCreatedAtUc);
                query = filter.DescendingByCreatedAt
                    ? query.OrderByDescending(m => m.CreatedAt)
                    : query.OrderBy(m => m.CreatedAt);
            }
            else
            {
                query.OrderByDescending(m => m.CreatedAt);
            }
            
            var totalCount = await query.CountAsync(cancellationToken: ct);

            var items = await query
                .Skip(page.Offset)
                .Take(page.PageSize)
                .ToListAsync(ct);
            List<MotoSummary> summaries = [];
            
            summaries.AddRange(items.Select(item =>  new MotoSummary{Id= item.Id, Placa= item.Placa.Valor, Modelo = item.Modelo}));
            
            return new PaginatedResult<MotoSummary>(summaries, totalCount, page.Page, page.PageSize);
        }
    }
}
