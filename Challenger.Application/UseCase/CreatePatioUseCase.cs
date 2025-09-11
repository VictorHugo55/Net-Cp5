using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using System.IO;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;

namespace Challenger.Application.UseCase;

public class CreatePatioUseCase
{
    private readonly IPatioRepository _patioRepository;

    public CreatePatioUseCase(IPatioRepository patioRepository)
    {
        _patioRepository = patioRepository;
    }

    public async Task<PatioResponse> Execute(PatioRequest request, string createdBy)
    {
        // Cria a entidade Patio com valores puros
        var patio = new Patio(
            request.Name,
            request.Cidade,
            request.Capacidade,
            createdBy   
        );

        // Salva no repositório
        await _patioRepository.AddAsync(patio);

        // Retorna DTO de resposta
        return new PatioResponse(
            patio.Id,
            patio.Name,
            patio.Cidade,
            patio.Capacidade
        );
    }
}