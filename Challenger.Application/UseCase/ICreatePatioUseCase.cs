using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;

namespace Challenger.Application.UseCase;

public interface ICreatePatioUseCase
{
    Task<PatioResponse> Execute(PatioRequest request, string createdBy);
}