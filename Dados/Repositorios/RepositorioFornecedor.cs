using Dominio.Entidades;
using Dominio.Repositorios;
using Fornecedores.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dados.Repositorios
{
    public class RepositorioFornecedor : Repositorio<Fornecedor>, IRepositorioFornecedor
    {
        public RepositorioFornecedor(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Fornecedor>> BuscarFornecedores()
        {
            return await _context.Fornecedores.Include(x => x.Empresa).Include(t => t.Telefones).ToListAsync();
        }

        public Task<Fornecedor> BuscarPorIdFornecedor(long id)
        {
            return _context.Fornecedores.Where( x => x.Id == id).Include(x => x.Empresa).Include(t => t.Telefones).FirstOrDefaultAsync();
        }
    }
}
