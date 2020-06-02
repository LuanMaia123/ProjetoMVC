using Dominio.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Empresa : Entidade
    {
        [DisplayName("UF")]
        public EstadoEnum Uf { get; set; }

        [Column("varchar(250)")]
        public string NomeFantasia { get; set; }

        [Column("varchar(14)")]
        public string Cnpj { get; set; }

        public ICollection<Fornecedor> fornecedores { get; set; }
    }
}