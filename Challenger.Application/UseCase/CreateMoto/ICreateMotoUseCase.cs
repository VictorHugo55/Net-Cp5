using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Application.pagination;

namespace Challenger.Application.UseCase;

public interface ICreateMotoUseCase
{
    Task<MotoResponse> Execute(MotoRequest request, string createdBy);

    Task<PaginatedResult<MotoSummary>> ExecuteAsync(
        PageRequest page,
        MotoQuery? filter = null,
        CancellationToken ct = default
    );

}