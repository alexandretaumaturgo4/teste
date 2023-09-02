using Backoffice.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Infra.Data.Context;

public class BackofficeContext : IdentityDbContext
{
    public BackofficeContext(DbContextOptions<BackofficeContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var property in builder.Model.GetEntityTypes().SelectMany(
                     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        {
            property.SetColumnType("varchar(100)");
        }
        
        builder.Entity<IdentityRole>()
            .HasData(
                new List<IdentityRole>
                {
                    new()
                    {
                        Name = "administrador",
                        NormalizedName = "ADMINISTRADOR",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    new()
                    {
                        Name = "usuario",
                        NormalizedName = "USUARIO",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    }
                }
            );

        builder.ApplyConfigurationsFromAssembly(typeof(BackofficeContext).Assembly);
    }
}