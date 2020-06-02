using Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public interface IServicoFornecedor
    {
        Task<FornecedorListModel> BuscarFornecedores(FornecedorListModel model);

        Task<FornecedorModel> BuscarPorIdFornecedor(long id);

        Task<FornecedorModel> Find(long Id);

        bool Incluir(FornecedorModel entidade);

        void Alterar(FornecedorModel entidade);

        void Excluir(FornecedorModel entidade);

        Task SaveChangesAsync();
    }
}