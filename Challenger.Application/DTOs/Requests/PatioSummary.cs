namespace Challenger.Application.DTOs.Requests;

public class PatioSummary
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Cidade { get; set; } 
    public int Capacidade { get; set; }
}