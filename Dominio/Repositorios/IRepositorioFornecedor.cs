using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IRepositorioFornecedor : IRepositorio<Fornecedor>
    {
        Task<IEnumerable<Fornecedor>> BuscarFornecedores();

        Task<Fornecedor> BuscarPorIdFornecedor(long id);
    }
}
