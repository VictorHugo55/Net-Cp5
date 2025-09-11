using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenger.Domain.Entities;

namespace Challenger.Domain.Interfaces
{
     public interface IMotoRepository:IRepository<Moto>
    {
        Task<Moto?> GetByPlacaAsync(string placa);
    }
}
