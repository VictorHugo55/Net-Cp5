using Challenger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenger.Infrastructure.Percistence.Mappings;

public class PatioMapping : IEntityTypeConfiguration<Patio>
{
    public void Configure(EntityTypeBuilder<Patio> builder)
    {
        builder.ToTable("Patios");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Cidade)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Capacidade)
            .IsRequired();
    }

    
}