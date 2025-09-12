namespace Challenger.Domain.Entities;

public class Patio : Audit
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Cidade { get; private set; }
    public int Capacidade { get; private set; }

    public List<Moto> Motos { get; private set; }

    // Construtor para criação
    public Patio(string name, string cidade, int capacidade, string createdBy)
    {
        Id = Guid.NewGuid();
        Name = name;
        Cidade = cidade;
        Capacidade = capacidade;

        SetCreated(createdBy);
    }

    // Construtor vazio para EF Core
    public Patio() { }

    // Atualização
    public void Update(string name, string cidade, int capacidade, string updatedBy)
    {
        Name = name;
        Cidade = cidade;
        Capacidade = capacidade;

        SetUpdated(updatedBy);
    }

    // Método para adicionar moto
    public void AdicionarMoto(Moto moto)
    {
        if (Motos.Count >= Capacidade)
            throw new InvalidOperationException("Pátio atingiu a capacidade máxima.");

        Motos.Add(moto);
    }

}