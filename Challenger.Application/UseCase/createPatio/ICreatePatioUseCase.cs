using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Application.pagination;

namespace Challenger.Application.UseCase;

public interface ICreatePatioUseCase
{
    Task<PatioResponse> Execute(PatioRequest request, string createdBy);
    
    Task<PaginatedResult<PatioSummary>> ExecuteAsync(
        PageRequest page,
        PatioQuery? filter = null,
        CancellationToken ct = default
    );
}