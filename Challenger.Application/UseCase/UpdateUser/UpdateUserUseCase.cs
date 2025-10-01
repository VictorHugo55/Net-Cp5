using Challenger.Application.DTOs.Requests;
using Challenger.Domain.Interfaces;
using Challenger.Domain.ValueObjects;

namespace Challenger.Application.UseCase.UpdateUser;

public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public UpdateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> Execute(Guid userId, UserRequest request, string updatedBy)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"Usuario com id: {userId}, Não foi encontrado");
        
        var emailVO = new UserEmail(request.Email);
        var senhaVO = new UserSenha(request.Senha);
        
        user.Update(
            request.Username,
            emailVO.Valor,
            senhaVO.Valor,
            updatedBy
        );
        
        await _userRepository.UpdateAsync(user);
        
        return true;
    }
}