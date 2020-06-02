using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Telefone : Entidade
    {
        [Column("varchar(12)")]
        public string Numero { get; set; }
        public long? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}