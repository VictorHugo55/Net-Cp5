using System.Text.RegularExpressions;

namespace Challenger.Domain.ValueObjects;

public class UserEmail
{
    public string Valor { get; private set; }

    public UserEmail(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("O e-mail não pode ser vazio.", nameof(valor));

        if (!ValidarEmail(valor))
            throw new ArgumentException("O e-mail fornecido não é válido.", nameof(valor));

        Valor = valor;
    }

    private bool ValidarEmail(string email)
    {
        string regexEmail = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        return Regex.IsMatch(email, regexEmail);
    }

    public override string ToString() => Valor;

}