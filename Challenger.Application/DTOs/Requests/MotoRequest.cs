using System.ComponentModel.DataAnnotations;
using Challenger.Domain;
using Challenger.Domain.Enum;

namespace Challenger.Application.DTOs.Requests;

public class MotoRequest
{
    [Required(ErrorMessage = "A placa é obrigatória")]
    [MinLength(7)]
    public string Placa { get; set; } = string.Empty; // string simples
    
    [Required(ErrorMessage = "O modelo é obrigatório")]
    public ModeloMoto Modelo { get; set; }
    
    [Required(ErrorMessage = "O status da moto é obrigatório")]
    public StatusMoto Status { get; set; }
    
    [Required(ErrorMessage = "O id do patio é obrigatório")]
    public Guid PatioId { get; set; }
}