using Aplicacao.Servicos;
using Dados.Repositorios;
using Dominio.Repositorios;
using Dominio.Servicos;
using Fornecedores.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class RegistrarDependencias
    {
        public static void Registrar(IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
            servicos.AddScoped<IServicoEmpresa, ServicoEmpresa>();
            servicos.AddScoped<IServicoFornecedor, ServicoFornecedor>();
            servicos.AddScoped<IRepositorioFornecedor, RepositorioFornecedor>();
            servicos.AddScoped<DbContext, ApplicationDbContext>();
        }
    }
}