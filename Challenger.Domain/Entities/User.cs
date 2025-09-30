using Challenger.Domain.ValueObjects;

namespace Challenger.Domain.Entities;

public class User : Audit
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public UserCredentials Credentials { get; private set; }

    public User()
    {
        
    }
    
    public User( string username, string email, string password, string createdBy)
    {
        Id = Guid.NewGuid();
        Username = username;
        Credentials = new UserCredentials(email, password);
        
        SetCreated(createdBy);
    }

    public void Update(string username, string email, string password, string updatedBy)
    {
        Username = username;
        Credentials = new UserCredentials(email, password);
        
        SetUpdated(updatedBy);
    }
    
}