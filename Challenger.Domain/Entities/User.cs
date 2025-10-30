using Challenger.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Challenger.Domain.Entities;

public class User : Audit
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; private set; }
    
    [BsonElement("username")]
    public string Username { get; private set; }
    
    [BsonElement("email")]
    public UserEmail Email { get; private set; }
    
    [BsonElement("senha")]
    public UserSenha Senha { get; private set; }

    public User()
    {
        
    }
    
    public User(string username, string email, string senha, string createBy)
        
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = new UserEmail(email);
        Senha = new UserSenha(senha);
        
        SetCreated(createBy);
    }
    
    public void Update(string username, string email, string senha, string updatedBy)
    {
        Username = username;
        Email = new UserEmail(email);
        Senha = new UserSenha(senha);
        
        SetUpdated(updatedBy);
    }
    
    
    
}