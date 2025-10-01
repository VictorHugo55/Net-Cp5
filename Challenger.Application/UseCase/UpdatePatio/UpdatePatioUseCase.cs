// Application/UseCases/UpdatePatioUseCase.cs
using Challenger.Application.DTOs.Requests;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Challenger.Application.UseCase;

public class UpdatePatioUseCase : IUpdatePatioUseCase
{
    private readonly IPatioRepository _patioRepository;

    public UpdatePatioUseCase(IPatioRepository patioRepository)
    {
        _patioRepository = patioRepository;
    }

    public async Task<bool> Execute(Guid id, PatioRequest request, string updatedBy)
    {
        var patioExistente = await _patioRepository.GetByIdAsync(id);

        if (patioExistente == null)
            return false;

        // Atualiza os dados no domínio
        patioExistente.Update(request.Name, request.Cidade, request.Capacidade, updatedBy);

        await _patioRepository.UpdateAsync(patioExistente);

        return true;
    }
}