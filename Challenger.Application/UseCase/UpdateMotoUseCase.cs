using System.Data.SqlTypes;
using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Domain.Interfaces;
using Challenger.Domain.ValueObjects;

namespace Challenger.Application.UseCase;

public class UpdateMotoUseCase : IUpdateMotoUseCase
{
    private readonly IMotoRepository _motoRepository;

    public UpdateMotoUseCase(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
    }

    public async Task<bool> Execute(Guid motoId, MotoRequest request, string updatedBy)
    {
        // Busca a moto existente
        var moto = await _motoRepository.GetByIdAsync(motoId);
        if (moto == null)
            throw new KeyNotFoundException("Moto não encontrada.");

        // Criação do VO PlacaMoto
        var placaVO = new PlacaMoto(request.Placa);

        // Atualiza a entidade
        moto.Update(
            placaVO.Valor,
            request.Modelo,
            request.PatioId,
            updatedBy
        );

        await _motoRepository.UpdateAsync(moto);

        return true;
    }
}