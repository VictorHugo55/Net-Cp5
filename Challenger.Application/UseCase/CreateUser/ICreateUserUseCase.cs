using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Application.pagination;

namespace Challenger.Application.UseCase;

public interface ICreateUserUseCase
{
    Task<UserResponse> Execute(UserRequest request, string createdBy);
    
    Task<PaginatedResult<UserSummary>> ExecuteAsync(
        PageRequest page,
        UserQuery? filter = null,
        CancellationToken ct = default
    );
}