using Challenger.Application.DTOs.Requests;
using Challenger.Application.pagination;
using Challenger.Domain.Entities;

namespace Challenger.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<List<User>> GetAllAsync();
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}