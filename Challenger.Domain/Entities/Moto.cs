using Challenger.Domain.Enum;
using Challenger.Domain.ValueObjects;

namespace Challenger.Domain.Entities;

public class Moto : Audit
{
    public Guid Id { get; private set; }
    public PlacaMoto Placa { get; private set; }

    public ModeloMoto Modelo { get; private set; }
    public StatusMoto Status { get; private set; }

    public Guid PatioId { get; private set; }
    public Patio Patio { get; private set; }
    
    public Moto() { }

    public Moto(string placa, ModeloMoto modelo,StatusMoto status, Guid patioId, string createBy)
    {
        Id = Guid.NewGuid();
        Placa = new PlacaMoto(placa);
        Modelo = modelo;
        Status = status;
        PatioId = patioId;

        SetCreated(createBy);
    }


    public void Update(string placa, ModeloMoto modelo, Guid patioId, string updatedBy)
    {
        Placa = new PlacaMoto(placa);
        Modelo = modelo;
        PatioId = patioId;

        SetUpdated(updatedBy);
    }

    public void Inativa() =>
            ChangeStatus(StatusMoto.INATIVA);

    public void Ativa() =>
        ChangeStatus(StatusMoto.DISPONIVEL);

    public void Manutencao() =>
        ChangeStatus(StatusMoto.EM_MANUTENCAO);

    public void Uso() =>
        ChangeStatus(StatusMoto.EM_USO);

    private void ChangeStatus(StatusMoto novoStatus)
    {
        if (Status == novoStatus)
            throw new InvalidOperationException($"A moto já está {novoStatus}");

        Status = novoStatus;
    }
}