using Challenger.Domain.ValueObjects;

namespace Challenger.Domain.Entities;

public class User : Audit
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public UserEmail Email { get; private set; }
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