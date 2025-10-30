using Challenger.Application.Configs;
using Google.Protobuf;
using MongoDB.Driver;

namespace Challenger.Infrastructure.MongoDB;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(Settings settings)
    {
        var client = new MongoClient(settings.MongoDb.ConnectionString);
        _database = client.GetDatabase(settings.MongoDb.DatabaseName);
    }
    
    public IMongoDatabase Database => _database;
}