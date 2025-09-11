using Challenger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Domain.Interfaces
{
    internal interface IPatioRepository
    {
        Task<Patio?> GetByNameAsync(string name);
        Task<List<Patio>> GetByCidadeAsync(string cidade);
    }
}
