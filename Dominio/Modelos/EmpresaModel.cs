using Dominio.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dominio.Modelos
{
    public class EmpresaModel
    {
        public long Id { get; set; }

        [DisplayName("UF")]
        [Required(ErrorMessage = "UF é um campo obrigatório")]
        public EstadoEnum Uf { get; set; }

        [Column("varchar(250)")]
        [DisplayName("Nome Fantasia")]
        [Required(ErrorMessage = "Nome Fantasia é um campo obrigatório")]
        public string NomeFantasia { get; set; }

        [Column("varchar(14)")]
        [Required(ErrorMessage = "CNPJ é um campo obrigatório")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        public List<SelectListItem> EstadoSelect { get; set; }

        public EmpresaModel()
        {
            EstadoSelect = new List<SelectListItem>();
            EstadoSelect.AddRange(Enum.GetNames(typeof(EstadoEnum)).Select(estado => new SelectListItem
            {
                Value = estado.ToString(),
                Text = estado.ToString()
            }).ToList());
        }
    }
}