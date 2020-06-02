using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Incluir(T entidade);

        void Alterar(T entidade);

        void Excluir(T entidade);

        void Excluir(List<T> entidade);

        void ExcluirPorId(long id);

        Task<T> ObterPeloId(long id);

        Task<IEnumerable<T>> ObterTodos();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        Task SaveChangesAsync();
    }
}