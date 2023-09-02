using Backoffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backoffice.Infra.Data.Mappings;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.ToTable("Pessoas");
        
        builder.Property(p => p.Qualificacao);

        builder.HasOne(p => p.PessoaFisica)
            .WithOne()
            .HasForeignKey<Pessoa>(p => p.PessoaFisicaId)
            .IsRequired(false);

        builder.HasOne(p => p.PessoaJuridica)
            .WithOne()
            .HasForeignKey<Pessoa>(p => p.PessoaJuridicaId)
            .IsRequired(false);
        
        builder.OwnsOne(x => x.Endereco, builder =>
        {
            builder.Property(x => x.Rua).HasMaxLength(50);
            builder.Property(x => x.Numero).HasMaxLength(50);
            builder.Property(x => x.Bairro).HasMaxLength(50);
            builder.Property(x => x.Cidade).HasMaxLength(50);
            builder.Property(x => x.Estado).HasMaxLength(50);
            builder.Property(x => x.Cep).HasMaxLength(50);
        });

        builder.Property(x => x.TipoPessoa);
        
        builder.Property(p => p.CreatedAt);

        builder.Property(p => p.UpdatedAt);

    }
}