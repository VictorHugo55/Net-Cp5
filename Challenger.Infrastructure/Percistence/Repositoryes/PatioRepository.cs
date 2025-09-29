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
    public class PatioRepository : Repository<Patio>, IPatioRepository
    {
        private readonly CGContext _context;
        private IPatioRepository _patioRepositoryImplementation;
        


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

        public async Task<PaginatedResult<PatioSummary>> GetPatioPageAsync(PageRequest page, PatioQuery? filter = null, CancellationToken ct = default)
        {
            page.EnsureValid();
            
            IQueryable<Patio> query = _context.Patios.AsNoTracking();
            if (filter is not null)
            {
                if (!string.IsNullOrEmpty(filter.Cidade))
                {
                    var cidade = filter.Cidade.Trim();
                    query = query.Where(p => p.Cidade.Contains(cidade));
                }

                if (filter.FromCreatedAtUc is not null)
                    query = query.Where(p => p.CreatedAt >= filter.FromCreatedAtUc);
                query = filter.DescendingByCreatedAt
                    ? query.OrderByDescending(p => p.CreatedAt)
                    : query.OrderBy(p => p.CreatedAt);
            }
            else
            {
                query.OrderByDescending(p => p.CreatedAt);
            }
            
            var totalCount = await query.CountAsync(cancellationToken: ct);
            var items = await query
                .Skip(page.Offset)
                .Take(page.PageSize)
                .ToListAsync(ct);
            List<PatioSummary> summaries = [];
            
            summaries.AddRange(items.Select(item => new PatioSummary(){Id = item.Id, Name = item.Name, Cidade = item.Cidade, Capacidade = item.Capacidade}));

            return new PaginatedResult<PatioSummary>(summaries, totalCount, page.Page, page.PageSize);
        }
    }
}
