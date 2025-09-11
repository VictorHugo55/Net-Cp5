namespace Challenger.Application.DTOs.Responses;

public class PatioResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public int Capacidade { get; set; }

    public PatioResponse(Guid id, string name, string cidade, int capacidade)
    {
        Id = id;
        Name = name;
        Cidade = cidade;
        Capacidade = capacidade;
    }
}