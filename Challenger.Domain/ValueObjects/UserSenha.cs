using System.Text.RegularExpressions;

namespace Challenger.Domain.ValueObjects;

public class UserSenha
{
    public string Valor { get; private set; }

    public UserSenha(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("A senha não pode ser vazia.", nameof(valor));

        if (!ValidarSenha(valor))
            throw new ArgumentException("A senha não é válida. Deve conter ao menos 6 caracteres, uma letra maiúscula, uma minúscula e um número.", nameof(valor));

        Valor = valor;
    }

    private bool ValidarSenha(string senha)
    {
        string regexSenha = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$";
        return Regex.IsMatch(senha, regexSenha);
    }

    public override string ToString() => "********"; 
}