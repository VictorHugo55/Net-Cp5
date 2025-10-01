using Challenger.Application.DTOs.Requests;

namespace Challenger.Application.UseCase;

public interface IUpdatePatioUseCase
{
    Task<bool> Execute(Guid id, PatioRequest request, string updatedBy);
}