using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenger.Application.DTOs.Requests;
using Challenger.Application.pagination;
using Challenger.Domain.Entities;

namespace Challenger.Domain.Interfaces
{
     public interface IMotoRepository:IRepository<Moto>
    {
        Task<Moto?> GetByPlacaAsync(string placa);
        
        Task<PaginatedResult<MotoSummary>> GetPageAsync(
            PageRequest page, 
            MotoQuery? filter = null, 
            CancellationToken ct = default
        );
    }
}
