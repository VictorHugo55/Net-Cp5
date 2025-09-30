namespace Challenger.Application.DTOs.Requests;

public class UserSummary
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; } = String.Empty;
    public string Senha { get; set; } = String.Empty;
}