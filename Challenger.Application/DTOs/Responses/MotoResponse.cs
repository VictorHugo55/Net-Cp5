using Challenger.Domain;
using Challenger.Domain.Enum;

namespace Challenger.Application.DTOs.Responses;

public class MotoResponse
{
    public Guid Id { get; set; }
    public string Placa { get; set; } = string.Empty;
    public ModeloMoto Modelo { get; set; }
    public StatusMoto Status { get; set; }
    public Guid PatioId { get; set; }

    public MotoResponse(Guid id, string placa, ModeloMoto modelo, StatusMoto status, Guid patioId)
    {
        Id = id;
        Placa = placa;
        Modelo = modelo;
        Status = status;
        PatioId = patioId;
    }
}