namespace Challenger.Domain.ValueObjects;
using System.Text.RegularExpressions;


public class PlacaMoto
{
    public string Valor { get; private set; }

    public PlacaMoto(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("Placa não pode ser vazia.");

        // Validação simples de placa (padrão antigo e Mercosul)
        var regex = new Regex(@"^[A-Z]{3}-[0-9]{4}$|^[A-Z]{3}[0-9][A-Z][0-9]{2}$");
        if (!regex.IsMatch(valor.ToUpper()))
            throw new ArgumentException("Placa inválida.");

        Valor = valor.ToUpper();
    }

    public override string ToString() => Valor;

    // Igualdade por valor
    public override bool Equals(object? obj)
        => obj is PlacaMoto other && Valor == other.Valor;

    public override int GetHashCode() => Valor.GetHashCode();

    // Operadores de comparação
    public static bool operator ==(PlacaMoto? left, PlacaMoto? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Valor == right.Valor;
    }

    public static bool operator !=(PlacaMoto? left, PlacaMoto? right)
        => !(left == right);
}
