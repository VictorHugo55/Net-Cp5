namespace Challenger.Application.DTOs.Requests;

public class PatioRequest
{
    public string Name { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public int Capacidade { get; set; }
}