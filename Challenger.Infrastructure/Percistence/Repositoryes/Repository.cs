using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenger.Domain.Interfaces;
using Challenger.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Challenger.Infrastructure.Percistence.Repositoryes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        

            private readonly CGContext _context;

            private readonly DbSet<T> _dbSet;

            public Repository(CGContext context)
            {
                _context = context;
                _dbSet = context.Set<T>();
            }

            public async Task AddAsync(T entity)
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(T entity)
            {
                if (entity == null) throw new ArgumentNullException(nameof(entity));

                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }

            public async Task<T?> GetByIdAsync(Guid id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task UpdateAsync(T entity)
            {
                if (entity == null) throw new ArgumentNullException(nameof(entity));

                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        
    }
}
