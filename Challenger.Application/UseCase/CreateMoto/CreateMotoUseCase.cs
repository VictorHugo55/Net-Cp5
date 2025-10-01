using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Application.pagination;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;
using Challenger.Domain.ValueObjects;

namespace Challenger.Application.UseCase.CreateMoto;

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

    public Task<PaginatedResult<MotoSummary>> ExecuteAsync(PageRequest page, MotoQuery? filter = null, CancellationToken ct = default)
    {
        return _motoRepository.GetPageAsync(page, filter, ct);
    }
}