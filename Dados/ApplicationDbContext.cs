using Dominio.Entidades;
using Dominio.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fornecedores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Fornecedor>()
            .HasOne(e => e.Empresa)
            .WithMany(c => c.fornecedores).HasForeignKey(s => s.EmpresaId)
            .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Fornecedor>()
           .HasMany(b => b.Telefones)
           .WithOne(t => t.Fornecedor)
           .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Empresa>()
     .HasData(
       new Empresa
       {
           Id = 1,
           Cnpj = "12.222.222/1111-11",
           NomeFantasia = "Pague Veloz",
           Uf = EstadoEnum.SC
       }
     );
        }
    }
}