using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Modelos
{
    public class FornecedorModel
    {
        public long Id { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataNascimento { get; set; }

        [Column("varchar(7)")]
        [DisplayName("RG")]
        public string Rg { get; set; }

        [Column("varchar(250)")]
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        public string Nome { get; set; }

        [Column("varchar(14)")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
       
        [Column("varchar(18)")]
        [MinLength(18,ErrorMessage ="Cnpj precisa conter 14 digitos")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        [DisplayName("Pessoa Jurídica")]
        [Required(ErrorMessage = "Pessoa Jurídica é um campo obrigatório")]
        public bool IsPessoaJuridica { get; set; }

        public List<TelefoneModel> Telefones { get; set; }

        [DisplayName("Empresa")]
        public long? EmpresaId { get; set; }

        public string EmpresaNome { get; set; }

        public string dataFormatada
        {
            get { return DataCadastro.ToShortDateString(); }
        }
        public bool isNovo { get; set; }

        public EmpresaModel Empresa { get; set; }

        public FornecedorModel()
        {
            Telefones = new List<TelefoneModel>();
            Telefones.Add(new TelefoneModel());
        }
    }
}