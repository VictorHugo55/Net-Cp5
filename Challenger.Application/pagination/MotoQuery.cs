using Challenger.Domain.Enum;
using Challenger.Domain.ValueObjects;

namespace Challenger.Application.pagination;

public class MotoQuery
{
    public ModeloMoto? Modelo { get; init; }
    
    public string? Placa { get; init; } = string.Empty;
    
    public DateTime? FromCreatedAtUc { get; init; }

    public bool DescendingByCreatedAt { get; init; } = true;
}