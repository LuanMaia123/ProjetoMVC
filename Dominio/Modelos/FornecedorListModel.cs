using System;
using System.Collections.Generic;

namespace Dominio.Modelos
{
    public class FornecedorListModel
    {
        public List<FornecedorModel> fornecedores { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public int RemainItens => PageSize < Count ? PageSize * CurrentPage : Count;
        public bool HasNext => !(CurrentPage < TotalPages);
        public bool HasPrev => CurrentPage == 1;
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime? Data { get; set; }

    }
}