﻿// <auto-generated />
using System;
using CadastroDePacientes.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroDePacientes.API.Data.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    partial class SqlServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CadastroDePacientes.API.Models.Convenio", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID")
                        .HasName("PK_Convenio");

                    b.ToTable("Convenios", (string)null);
                });

            modelBuilder.Entity("CadastroDePacientes.API.Models.Paciente", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("char");

                    b.Property<string>("CarteirinhaDoConvenio")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Celular")
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<Guid?>("ConvenioID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TelefoneFixo")
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<string>("UFDoRG")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("char");

                    b.Property<DateTime?>("ValidadeDaCarteirinha")
                        .HasColumnType("date");

                    b.HasKey("ID")
                        .HasName("PK_Paciente");

                    b.HasIndex("CPF")
                        .IsUnique()
                        .HasFilter("[CPF] IS NOT NULL");

                    b.HasIndex("ConvenioID");

                    b.ToTable("Pacientes", null, t =>
                        {
                            t.HasCheckConstraint("CK_UmTelefoneInformado", "([Celular] IS NULL AND [TelefoneFixo] IS NOT NULL OR [Celular] IS NOT NULL AND [TelefoneFixo] IS NULL OR [Celular] IS NOT NULL AND [TelefoneFixo] IS NOT NULL)");
                        });
                });

            modelBuilder.Entity("CadastroDePacientes.API.Models.Paciente", b =>
                {
                    b.HasOne("CadastroDePacientes.API.Models.Convenio", "Convenio")
                        .WithMany()
                        .HasForeignKey("ConvenioID");

                    b.Navigation("Convenio");
                });
#pragma warning restore 612, 618
        }
    }
}
