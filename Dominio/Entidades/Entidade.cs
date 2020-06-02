using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Entidade
    {
        [Key]
        public long Id { get; set; }
    }
}