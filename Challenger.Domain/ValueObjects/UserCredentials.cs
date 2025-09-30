using System.Text.RegularExpressions;

namespace Challenger.Domain.ValueObjects;

public class UserCredentials
{
    public string Email { get; }
    public string Senha { get; }

    // Construtor
    public UserCredentials(string email, string senha)
    {
        if (string.IsNullOrEmpty(email)) 
            throw new ArgumentException("O e-mail não pode ser vazio.", nameof(email));
        if (string.IsNullOrEmpty(senha)) 
            throw new ArgumentException("A senha não pode ser vazia.", nameof(senha));
            
        if (!ValidarEmail(email))
            throw new ArgumentException("O e-mail fornecido não é válido.", nameof(email));

        if (!ValidarSenha(senha))
            throw new ArgumentException("A senha não é válida. Deve conter ao menos 6 caracteres, uma letra maiúscula, uma minúscula e um número.", nameof(senha));

        Email = email;
        Senha = senha;
    }

    // Validação de e-mail
    private bool ValidarEmail(string email)
    {
        string regexEmail = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        return Regex.IsMatch(email, regexEmail);
    }

    // Validação de senha
    private bool ValidarSenha(string senha)
    {
        string regexSenha = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$";
        return Regex.IsMatch(senha, regexSenha);
    }
}