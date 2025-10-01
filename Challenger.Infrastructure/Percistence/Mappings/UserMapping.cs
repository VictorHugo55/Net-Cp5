using System.Text.Json;
using Challenger.Domain.Entities;
using Challenger.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenger.Infrastructure.Percistence.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(u => u.Email)
            .HasConversion(u => u.Valor, v => new UserEmail(v))
            .IsRequired();
        
        builder.Property(u => u.Senha)
            .HasConversion(u => u.Valor, v => new UserSenha(v))
            .IsRequired();
    }
}