using Challenger.Domain.Enum;

namespace Challenger.Domain.Entities;

public class Moto : Audit
{
    public Guid Id { get; private set; }
    public string Placa { get; set; }

    public ModeloMoto Modelo { get; set; }
    public StatusMoto Status { get; set; }

    public Guid PatioId { get; set; }
    public Patio Patio { get; set; }
    
    public Moto() { }

    public Moto(string placa, ModeloMoto modelo, Guid patioId, string createBy)
    {
        Id = Guid.NewGuid();
        Placa = placa;
        Modelo = modelo;
        Status = StatusMoto.INATIVA;
        PatioId = patioId;

        SetCreated(createBy);
    }


    public void Update(string placa, ModeloMoto modelo, Guid patioId, string updatedBy)
    {
        Placa = placa;
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