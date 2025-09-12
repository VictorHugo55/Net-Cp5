using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;

namespace Challenger.Application.UseCase;

public interface ICreateMotoUseCase
{
    Task<MotoResponse> Execute(MotoRequest request, string createdBy);
    
}