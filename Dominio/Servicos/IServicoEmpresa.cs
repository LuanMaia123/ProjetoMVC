using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public interface IServicoEmpresa
    {
        Task<EmpresaListModel> BuscarEmpresas(EmpresaListModel model);

        Task<List<EmpresaModel>> BuscarEmpresasAutoComplete(string search);

        Task<EmpresaModel> Find(long Id);

        void Incluir(EmpresaModel entidade);

        void Alterar(EmpresaModel entidade);

        void Excluir(EmpresaModel entidade);

        Task SaveChangesAsync();
    }
}