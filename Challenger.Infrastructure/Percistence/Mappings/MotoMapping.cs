using Challenger.Domain.Entities;
using Challenger.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenger.Infrastructure.Percistence.Mappings;

public class MotoMapping : IEntityTypeConfiguration<Moto>
{
    public void Configure(EntityTypeBuilder<Moto> builder)
    {
        builder.ToTable("Motos");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Placa)
            .HasConversion(p => p.Valor, v => new PlacaMoto(v)) // se for VO
            .IsRequired();

        builder.Property(m => m.Modelo)
            .IsRequired();

        builder.Property(m => m.Status)
            .HasConversion<int>() // salva enum como int
            .IsRequired();

        builder.HasOne(m => m.Patio)
            .WithMany(p => p.Motos)
            .HasForeignKey(m => m.PatioId);
    }
    
}