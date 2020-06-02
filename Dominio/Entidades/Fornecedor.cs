using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Fornecedor : Entidade
    {
        public DateTime DataCadastro { get; set; }
        public DateTime? DataNascimento { get; set; }

        [Column("varchar(7)")]
        public string Rg { get; set; }

        [Column("varchar(250)")]
        [Required]
        public string Nome { get; set; }

        [Column("varchar(11)")]
        public string Cpf { get; set; }

        [Column("varchar(14)")]
        public string Cnpj { get; set; }

        [Required]
        public bool IsPessoaJuridica { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
        public long? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}