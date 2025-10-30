using System.Net.Mail;
using Challenger.Application.DTOs.Requests;
using Challenger.Application.pagination;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;
using Challenger.Infrastructure.Context;
using Challenger.Infrastructure.MongoDB;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Challenger.Infrastructure.Percistence.Repositoryes;

public class UserRepository(MongoContext context):  IUserRepository
{
    private readonly IMongoCollection<User> _collection = context.Database.GetCollection<User>("Users");

    public async Task<List<User>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _collection.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(u => u.Id == id);
    }
}