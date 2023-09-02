using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Infra.Data.Mappings;

public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.ToTable("PessoasJuridicas");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.RazaoSocial).IsRequired().HasMaxLength(100);
        builder.Property(p => p.NomeFantasia).IsRequired().HasMaxLength(100);

        builder.Property(p => p.CreatedAt);

        builder.Property(p => p.UpdatedAt);


        builder.OwnsOne(x => x.Cnpj,
            builder =>
            {
                builder.Property(x => x.Valor).HasColumnName("CNPJ").HasMaxLength(14);
                builder.HasIndex(p => p.Valor).IsUnique();

            });
    }
}