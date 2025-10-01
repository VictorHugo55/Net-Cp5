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
        var emailVO = new UserEmail(request.Email);
        var senhaVO = new UserSenha(request.Senha);

        var user = new User(
            emailVO.Valor,
            senhaVO.Valor,
            request.Username,
            createdBy
            
        );
        
        await _userRepository.AddAsync(user);

        return new UserResponse(
            user.Id,
            user.Username,
            user.Email.ToString(),
            user.Senha.ToString()
        );
    }

    public Task<PaginatedResult<UserSummary>> ExecuteAsync(PageRequest page, MotoQuery? filter = null, CancellationToken ct = default)
    {
        return _createUserUseCaseImplementation.ExecuteAsync(page, filter, ct);
    }
}