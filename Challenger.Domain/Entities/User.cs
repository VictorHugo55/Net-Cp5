namespace Challenger.Domain.Entities;

public class User : Audit
{
    public Guid ID { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User()
    {
        
    }
    
    public User( string username, string email, string password, string createdBy)
    {
        ID = Guid.NewGuid();
        Username = username;
        Email = email; 
        Password = password;
        
        SetCreated(createdBy);
    }

    public void Update(string Username, string Email, string Password, string updatedBy)
    {
        this.Username = Username;
        this.Email = Email;
        this.Password = Password;
        
        SetUpdated(updatedBy);
    }
    
}