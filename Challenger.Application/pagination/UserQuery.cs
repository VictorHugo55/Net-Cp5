namespace Challenger.Application.pagination;

public class UserQuery
{
    public string? Username { get; init; }
    public string? Email { get; init; }
    
    public DateTime? FromCreatedAtUc { get; init; }
    public bool DescendingByCreatedAt { get; init; } = true;
}