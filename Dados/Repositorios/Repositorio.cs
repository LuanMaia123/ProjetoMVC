using System.Collections.Generic;
using System.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Fornecedores.Data;

namespace Dados.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade
    {
        protected ApplicationDbContext _context { get; }
        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Alterar(T entidade)
        {
            _context.Set<T>().Update(entidade);
        }

        public void Excluir(List<T> entidades)
        {
            foreach (var entidade in entidades)
            {
                Excluir(entidade);
            }
        }
        public void Excluir(T entidade)
        {
            if (entidade == null)
                return;
            try
            {
                _context.Set<T>().Remove(entidade);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async void ExcluirPorId(long Id)
        {
            T entidade = await ObterPeloId(Id);

            if (entidade == null)
                return;

            Excluir(entidade);
        }

        public void Incluir(T entidade)
        {
            _context.Set<T>().Add(entidade);
        }

        public Task<T> ObterPeloId(long Id)
        {
            if (Id == 0)
            {
                return null;
            }
            return _context.Set<T>().FindAsync(Id);

        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
