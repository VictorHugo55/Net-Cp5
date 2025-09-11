using Challenger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Domain.Interfaces
{
    public interface IPatioRepository:IRepository<Patio>
    {
        Task<IEnumerable<Patio>> GetByCidadeAsync(string cidade);
    }
}
