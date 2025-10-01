using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Application.pagination;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;
using Challenger.Domain.ValueObjects;

namespace Challenger.Application.UseCase.CreateUser;

public class CreateUserUseCase : ICreateUserUseCase
{   
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserResponse> Execute(UserRequest request, string createdBy)
    {
        var emailVo = new UserEmail(request.Email);
        var senhaVo = new UserSenha(request.Senha);

        var user = new User(
            request.Username,
            emailVo.Valor,
            senhaVo.Valor,
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

    public Task<PaginatedResult<UserSummary>> ExecuteAsync(PageRequest page, UserQuery? filter = null, CancellationToken ct = default)
    {
        return _userRepository.GetPageAsync(page, filter, ct);
    }
}