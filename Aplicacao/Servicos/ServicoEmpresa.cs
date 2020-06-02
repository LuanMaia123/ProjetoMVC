using AutoMapper;
using Dominio.Entidades;
using Dominio.Modelos;
using Dominio.Repositorios;
using Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class ServicoEmpresa : IServicoEmpresa
    {
        private readonly IRepositorio<Empresa> _repositorioEmpresa;
        private readonly IMapper _mapper;

        public ServicoEmpresa(IRepositorio<Empresa> repositorioEmpresa, IMapper mapper)
        {
            _repositorioEmpresa = repositorioEmpresa;
            _mapper = mapper;
        }

        public async Task<EmpresaListModel> BuscarEmpresas(EmpresaListModel model)
        {
            var empresas = await _repositorioEmpresa.ObterTodos();
           
            model.Count = empresas.Count();
            empresas = empresas.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize);
            List<EmpresaModel> empresasModel = _mapper.Map<List<Empresa>, List<EmpresaModel>>(empresas.ToList());

            model.empresas = empresasModel;
            return model;
        }

        public async Task<List<EmpresaModel>> BuscarEmpresasAutoComplete(string search)
        {
            var empresas = await _repositorioEmpresa.ObterTodos();
            if (!string.IsNullOrWhiteSpace(search))
            {
                empresas= empresas.OrderBy(l => l.NomeFantasia).Where(l => l.NomeFantasia.ToUpper().Contains(search.ToUpper())).ToList();
            }
            else
            {
                empresas = empresas.OrderBy(l => l.NomeFantasia).ToList();
            }

            return _mapper.Map<List<Empresa>, List<EmpresaModel>>(empresas.ToList());
        }
        public async Task<EmpresaModel> Find(long Id)
        {
            var empresa = await _repositorioEmpresa.ObterPeloId(Id);
            EmpresaModel empresaModel = _mapper.Map<Empresa, EmpresaModel>(empresa);
            return empresaModel;
        }

        public void Incluir(EmpresaModel entidade)
        {
            var empresa = _mapper.Map<EmpresaModel, Empresa>(entidade);
            _repositorioEmpresa.Incluir(empresa);
        }
        public void Alterar(EmpresaModel entidade)
        {
            var empresa = _mapper.Map<EmpresaModel, Empresa>(entidade);
            _repositorioEmpresa.Alterar(empresa);
        }
        public void Excluir(EmpresaModel entidade)
        {
            var empresa = _mapper.Map<EmpresaModel, Empresa>(entidade);
            _repositorioEmpresa.Excluir(empresa);
        }

        public async Task SaveChangesAsync()
        {
            await _repositorioEmpresa.SaveChangesAsync();
        }
    }
}