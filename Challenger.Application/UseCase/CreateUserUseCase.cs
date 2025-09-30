using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Application.pagination;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;
using Challenger.Domain.ValueObjects;

namespace Challenger.Application.UseCase;

public class CreateUserUseCase : ICreateUserUseCase
{   
    private readonly IUserRepository _userRepository;
    private ICreateUserUseCase _createUserUseCaseImplementation;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserResponse> Execute(UserRequest request, string createdBy)
    {
        var credentials = new UserCredentials(request.Email, request.Senha);

        var user = new User(
            request.Username,
            credentials.Email,
            credentials.Senha,
            createdBy
        );
        
        await _userRepository.AddAsync(user);

        return new UserResponse(
            user.Id,
            user.Username,
            user.Credentials.Email,
            user.Credentials.Senha
        );
    }

    public Task<PaginatedResult<UserSummary>> ExecuteAsync(PageRequest page, MotoQuery? filter = null, CancellationToken ct = default)
    {
        return _createUserUseCaseImplementation.ExecuteAsync(page, filter, ct);
    }
}