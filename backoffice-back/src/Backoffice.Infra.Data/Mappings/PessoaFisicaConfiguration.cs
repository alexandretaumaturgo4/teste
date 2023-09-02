using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Infra.Data.Mappings;

public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder.ToTable("PessoasFisicas");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Apelido).IsRequired().HasMaxLength(100);

        builder.Property(p => p.CreatedAt);

        builder.Property(p => p.UpdatedAt);

        builder.OwnsOne(x => x.Cpf,
            builder =>
            {
                builder.Property(x => x.Valor).HasColumnName("CPF").HasMaxLength(11);
                builder.HasIndex(x => x.Valor).IsUnique();
            });
    }
}