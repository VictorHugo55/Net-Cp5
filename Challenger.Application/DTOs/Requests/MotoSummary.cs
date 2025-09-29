using Challenger.Domain;
using Challenger.Domain.Enum;

namespace Challenger.Application.DTOs.Requests;

public class MotoSummary
{
    public Guid Id { get; set; }
    public string Placa { get; set; } = string.Empty;
    public ModeloMoto Modelo { get; set; }
    
}