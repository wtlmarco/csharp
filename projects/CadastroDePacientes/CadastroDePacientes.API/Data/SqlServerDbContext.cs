using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using CadastroDePacientes.API.Models;
using System.Threading;

namespace CadastroDePacientes.API.Data;

internal class SqlServerDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Convenio> Convenios { get; set; }

    public SqlServerDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Paciente>(entity =>
        {
            entity.ToTable("Pacientes");

            entity.Property(p => p.Nome).HasMaxLength(50).IsRequired();

            entity.Property(c => c.Sobrenome).HasMaxLength(100).IsRequired();

            entity.Property(p => p.DataDeNascimento).HasColumnType("date").IsRequired();

            entity.Property(c => c.Genero).HasMaxLength(50).IsRequired();

            entity.Property(c => c.CPF).HasColumnType("char").HasMaxLength(11);

            entity.Property(c => c.RG).HasColumnType("varchar").HasMaxLength(20).IsRequired();

            entity.Property(c => c.UFDoRG).HasColumnType("char").HasMaxLength(2).IsRequired();

            entity.Property(c => c.Email).HasMaxLength(256).IsRequired();

            entity.Property(c => c.Celular).HasColumnType("varchar").HasMaxLength(15);

            entity.Property(c => c.TelefoneFixo).HasColumnType("varchar").HasMaxLength(15);

            entity.Property(c => c.CarteirinhaDoConvenio).HasColumnType("varchar").HasMaxLength(50);

            entity.Property(p => p.ValidadeDaCarteirinha).HasColumnType("date");

            entity.HasKey(p => p.ID).HasName("PK_Paciente");

            entity.HasIndex(p => p.CPF).IsUnique();

            entity.ToTable(t => t.HasCheckConstraint("CK_UmTelefoneInformado",
                "([Celular] IS NULL AND [TelefoneFixo] IS NOT NULL OR [Celular] IS NOT NULL AND [TelefoneFixo] IS NULL OR [Celular] IS NOT NULL AND [TelefoneFixo] IS NOT NULL)"));
        });

        builder.Entity<Convenio>(entity =>
        {
            entity.ToTable("Convenios");

            entity.Property(c => c.Nome).HasColumnType("nvarchar(150)").IsRequired();

            entity.HasKey(c => c.ID).HasName("PK_Convenio");
        });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);

        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
            .HaveColumnType("date");
    }
}
