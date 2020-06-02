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
    public class ServicoFornecedor : IServicoFornecedor
    {
        private readonly IRepositorioFornecedor _repositorioFornecedor;
        private readonly IRepositorio<Telefone> _repositorioTelefone;
        private readonly IMapper _mapper;

        public ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor, IRepositorio<Telefone> repositorioTelefone, IMapper mapper)
        {
            _repositorioFornecedor = repositorioFornecedor;
            _repositorioTelefone = repositorioTelefone;
            _mapper = mapper;
        }

        public async Task<FornecedorListModel> BuscarFornecedores(FornecedorListModel model)
        {
            var fornecedores = await _repositorioFornecedor.BuscarFornecedores();
            if (!string.IsNullOrWhiteSpace(model.Nome))
            {
                fornecedores = fornecedores.Where(f => f.Nome.Contains(model.Nome));
            }
            if (!string.IsNullOrWhiteSpace(model.Cpf))
            {
                fornecedores = fornecedores.Where(f => !string.IsNullOrWhiteSpace(f.Cpf) && f.Cpf.Equals(model.Cpf));
            }
            if (!string.IsNullOrWhiteSpace(model.Cnpj))
            {
                fornecedores = fornecedores.Where(f => !string.IsNullOrWhiteSpace(f.Cnpj) && f.Cnpj.Equals(model.Cnpj));
            }
            if (model.Data.HasValue)
            {
                fornecedores = fornecedores.Where(f => f.DataCadastro >= model.Data && f.DataCadastro <= model.Data?.AddTicks(-1).AddDays(1));
            }
            model.Count = fornecedores.Count();
            fornecedores = fornecedores.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize);

            List<FornecedorModel> fornecedoresModel = _mapper.Map<List<Fornecedor>, List<FornecedorModel>>(fornecedores.ToList());
            model.fornecedores = fornecedoresModel;
            return model;
        }

        public async Task<FornecedorModel> Find(long Id)
        {
            var fornecedor = await _repositorioFornecedor.ObterPeloId(Id);
            FornecedorModel fornecedorModel = _mapper.Map<Fornecedor, FornecedorModel>(fornecedor);
            return fornecedorModel;
        }

        public bool Incluir(FornecedorModel entidade)
        {
            if (entidade.DataNascimento != null && entidade.EmpresaNome.Equals("Paraná"))
            {
                if (CalculaIdade(entidade.DataNascimento))
                {
                    return false;
                }
                else
                {
                    entidade.Telefones.RemoveAll(x => string.IsNullOrWhiteSpace(x.Numero));
                    var fornecedor = _mapper.Map<FornecedorModel, Fornecedor>(entidade);
                    fornecedor.DataCadastro = DateTime.Now;
                    _repositorioFornecedor.Incluir(fornecedor);
                }
            }
            else
            {
                var fornecedor = _mapper.Map<FornecedorModel, Fornecedor>(entidade);
                _repositorioFornecedor.Incluir(fornecedor);
            }
            return true;

        }

        public static bool CalculaIdade(DateTime? dataNascimento)
        {
            if (dataNascimento.HasValue)
            {
                int? idade = DateTime.Now.Year - dataNascimento?.Year;
                if (DateTime.Now.DayOfYear < dataNascimento?.DayOfYear)
                {
                    idade = idade - 1;
                }
                return idade < 18;
            }
            return false;

        }
        public void Alterar(FornecedorModel entidade)
        {
            entidade.Telefones.RemoveAll(x => string.IsNullOrWhiteSpace(x.Numero));
            List<Telefone> telefones = _repositorioTelefone.Find(x => x.FornecedorId == entidade.Id).ToList();
            _repositorioTelefone.Excluir(telefones);
            var fornecedor = _mapper.Map<FornecedorModel, Fornecedor>(entidade);
            _repositorioFornecedor.Alterar(fornecedor);
        }
        public void Excluir(FornecedorModel entidade)
        {
            try
            {
                var fornecedor = _mapper.Map<FornecedorModel, Fornecedor>(entidade);
                _repositorioFornecedor.Excluir(fornecedor);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task SaveChangesAsync()
        {
            await _repositorioFornecedor.SaveChangesAsync();
        }

        public async Task<FornecedorModel> BuscarPorIdFornecedor(long id)
        {
            var fornecedor = await _repositorioFornecedor.BuscarPorIdFornecedor(id);
            FornecedorModel fornecedorModel = _mapper.Map<Fornecedor, FornecedorModel>(fornecedor);
            return fornecedorModel;
        }
    }
}