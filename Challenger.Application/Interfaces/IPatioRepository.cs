using Challenger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenger.Application.DTOs.Requests;
using Challenger.Application.pagination;

namespace Challenger.Domain.Interfaces
{
    public interface IPatioRepository:IRepository<Patio>
    {
        Task<IEnumerable<Patio>> GetByCidadeAsync(string cidade);

        Task<PaginatedResult<PatioSummary>> GetPatioPageAsync(
            PageRequest page,
            PatioQuery? filter = null,
            CancellationToken ct = default
            );
    }
}
