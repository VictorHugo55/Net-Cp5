using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Domain.Interfaces
{
    internal interface IRepository <T> where T : class
    {
        Task AddAsync(T entity);
        Task<T?> GetByIdAssync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
        void Delete(T entity);
    }
}
