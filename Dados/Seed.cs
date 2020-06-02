using Dominio.Entidades;
using Fornecedores.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dados
{
    public class Seed
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (!context.Fornecedores.Any())
            {
                var Fornecedores = new List<Fornecedor>{
            new Fornecedor
            {
                Nome= "Fornecedor 1",
                DataCadastro = DateTime.Now.AddMonths(-2),
                Cnpj= "12.345.678/9123-22",
                Telefones= new []{new Telefone(){Numero  = "(99)99999-9999" },new Telefone(){Numero  = "(99)99999-9999" } }.ToList(),
                IsPessoaJuridica = true,
                Empresa= context.Empresas.FirstOrDefault(),
            },
            new Fornecedor
            {
                Nome= "Fornecedor 2",
                DataCadastro = DateTime.Now.AddMonths(-2),
                Cpf= "012.993.112-83",
                Telefones= new []{new Telefone(){Numero  = "(99)99999-9999" } }.ToList(),
                IsPessoaJuridica = false,
                Empresa= context.Empresas.FirstOrDefault(),
            },
            new Fornecedor
            {
                Nome= "Fornecedor 3",
                DataCadastro = DateTime.Now.AddMonths(-2),
                Cpf= "009.323.447-12",
                Telefones= new []{new Telefone(){Numero  = "(99)99999-9999" } }.ToList(),
                IsPessoaJuridica = false,
                Empresa= context.Empresas.FirstOrDefault(),
            }
        };
                context.Fornecedores.AddRange(Fornecedores);
                context.SaveChanges();
            }
        }
    }
}