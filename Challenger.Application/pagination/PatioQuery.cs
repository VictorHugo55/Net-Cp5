namespace Challenger.Application.pagination;

public class PatioQuery
{
    public string? Cidade { get; init; }
    public string? Name { get; init; }
    public DateTime? FromCreatedAtUc { get; init; }

    public bool DescendingByCreatedAt { get; init; } = true;
}