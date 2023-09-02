using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Infra.Data.Mappings;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamentos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);

        builder.HasIndex(p => p.Nome).IsUnique();

        builder.Property(p => p.CreatedAt);
        
        builder.Property(p => p.UpdatedAt);

        builder.HasOne(x => x.Responsavel)
            .WithMany()
            .HasForeignKey(x => x.ResponsavelId);
    }
}