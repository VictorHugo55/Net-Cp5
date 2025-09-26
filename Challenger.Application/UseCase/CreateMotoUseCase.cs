using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Domain.ValueObjects;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;

namespace Challenger.Application.UseCase;

public class CreateMotoUseCase :  ICreateMotoUseCase
{
    private readonly IMotoRepository _motoRepository;

    public CreateMotoUseCase(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
    }

    public async Task<MotoResponse> Execute(MotoRequest request, string createdBy)
    {
        // Criação do VO PlacaMoto a partir do DTO
        var placaVO = new PlacaMoto(request.Placa);

        var moto = new Moto(
            placaVO.Valor,  // VO usado no construtor da entidade
            request.Modelo,
            request.Status,
            request.PatioId,
            createdBy
        );

        await _motoRepository.AddAsync(moto);

        return new MotoResponse(
            moto.Id,
            moto.Placa.ToString(),
            moto.Modelo,
            moto.Status,
            moto.PatioId
        );
    }
}