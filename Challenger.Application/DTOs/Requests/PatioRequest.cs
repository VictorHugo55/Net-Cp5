using System.ComponentModel.DataAnnotations;

namespace Challenger.Application.DTOs.Requests;

public class PatioRequest
{
    [Required(ErrorMessage = "O nome é necessário")]
    public string Name { get; set; } 
    [Required(ErrorMessage = "A Cidade é obrigatória")]
    public string Cidade { get; set; } 
    [Required(ErrorMessage = "A Capacidade é obrigatória")]
    public int Capacidade { get; set; }
}