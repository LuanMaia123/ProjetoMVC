﻿// <auto-generated />
using System;
using Fornecedores.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dados.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Dominio.Entidades.Empresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cnpj")
                        .HasColumnName("varchar(14)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnName("varchar(250)");

                    b.Property<int>("Uf");

                    b.HasKey("Id");

                    b.ToTable("Empresas");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Cnpj = "12.222.222/1111-11",
                            NomeFantasia = "Pague Veloz",
                            Uf = 23
                        });
                });

            modelBuilder.Entity("Dominio.Entidades.Fornecedor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cnpj")
                        .HasColumnName("varchar(14)");

                    b.Property<string>("Cpf")
                        .HasColumnName("varchar(11)");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<long?>("EmpresaId");

                    b.Property<bool>("IsPessoaJuridica");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("varchar(250)");

                    b.Property<string>("Rg")
                        .HasColumnName("varchar(7)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Dominio.Entidades.Telefone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("FornecedorId");

                    b.Property<string>("Numero")
                        .HasColumnName("varchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("Dominio.Entidades.Fornecedor", b =>
                {
                    b.HasOne("Dominio.Entidades.Empresa", "Empresa")
                        .WithMany("fornecedores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Dominio.Entidades.Telefone", b =>
                {
                    b.HasOne("Dominio.Entidades.Fornecedor", "Fornecedor")
                        .WithMany("Telefones")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
