using Challenger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Challenger.Infrastructure.Percistence.Mappings;

namespace Challenger.Infrastructure.Context
{
    internal class CGContext(DbContextOptions<CGContext> options) : DbContext(options)
    {
        
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Patio> Patios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica os mappings separados
            modelBuilder.ApplyConfiguration(new MotoMapping());
            modelBuilder.ApplyConfiguration(new PatioMapping());
        }
    }
}
