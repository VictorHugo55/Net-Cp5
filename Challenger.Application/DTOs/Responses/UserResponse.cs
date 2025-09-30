namespace Challenger.Application.DTOs.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;

    public UserResponse(Guid id, string username, string email, string senha)
    {
        Id = id;
        Username = username;
        Email = email;
        Senha = senha;
    }
}