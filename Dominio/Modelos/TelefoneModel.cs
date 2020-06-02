using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Modelos
{
    public class TelefoneModel
    {
        public long Id { get; set; }

        [Column("varchar(12)")]
        [DisplayName("Telefone")]
        public string Numero { get; set; }
    }
}