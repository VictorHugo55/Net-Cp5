using Challenger.Application.DTOs.Requests;

namespace Challenger.Application.UseCase;

public interface IUpdateUserUseCase
{
    Task<bool> Execute(Guid userId, UserRequest request, string updatedBy);
}