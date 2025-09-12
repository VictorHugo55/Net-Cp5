using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;

namespace Challenger.Application.UseCase;

public interface IUpdateMotoUseCase
{
    Task<bool> Execute(Guid motoId, MotoRequest request, string updatedBy);
}