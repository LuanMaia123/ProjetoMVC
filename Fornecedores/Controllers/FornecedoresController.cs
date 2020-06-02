using Dominio.Modelos;
using Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fornecedores.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IServicoFornecedor _servico;
        private readonly IServicoEmpresa _servicoEmpresa;

        public FornecedoresController(IServicoFornecedor servico, IServicoEmpresa servicoEmpresa)
        {
            _servico = servico;
            _servicoEmpresa = servicoEmpresa;
        }

        public async Task<IActionResult> Index(string button,[Bind("Nome ,Cnpj,Cpf, Data, CurrentPage")] FornecedorListModel model)
        {
            model = await _servico.BuscarFornecedores(model);
            if (button == "Limpar")
            {
                ModelState.Clear();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("DataNascimento ,IsPessoaJuridica, Rg, Nome, Cnpj, Cpf, Id, Telefones, DataCadastro, EmpresaId, EmpresaNome,isNovo")] FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (fornecedor.Id == 0)
                    {
                        if (fornecedor.IsPessoaJuridica)
                        {
                            if (string.IsNullOrWhiteSpace(fornecedor.Cnpj))
                            {
                                this.AddAlertWarning("Campo CNPJ é obrigatório.");
                                return View(fornecedor);
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(fornecedor.Rg))
                        {
                            this.AddAlertWarning("Campo RG é obrigatório.");
                            return View(fornecedor);
                        }
                        else if (fornecedor.DataNascimento == null)
                        {
                            this.AddAlertWarning("Campo data de nascimento é obrigatório.");
                            return View(fornecedor);
                        }
                        bool incluir = _servico.Incluir(fornecedor);
                        if (incluir)
                        {
                            this.AddAlertSuccess("Fornecedor incluido com sucesso.");
                        }
                        else
                        {
                            this.AddAlertInfo("Apenas pessoa física maior de idade pode ser cadastrada na empresa Paraná.");
                            return View(fornecedor);
                        }
                    }
                    else
                    {
                        _servico.Alterar(fornecedor);
                        this.AddAlertSuccess("Fornecedor alterado com sucesso.");
                    }

                    await _servico.SaveChangesAsync();
                    return base.RedirectToAction(nameof(Index));
                }
                return View(fornecedor);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<IActionResult> AddOrEdit(long id = 0)
        {
            if (id == 0)
            {
                FornecedorModel model = new FornecedorModel();
                model.isNovo = true;
                return base.View(model);
            }
            else
            {
                FornecedorModel model = await _servico.BuscarPorIdFornecedor(id);
                model.isNovo = false;
                return base.View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTelefone([Bind("Telefones")] FornecedorModel fornecedor)
        {
            fornecedor.Telefones.Add(new TelefoneModel());
            return PartialView("TelefonesModel", fornecedor);
        }


        public async Task<IActionResult> Delete(long id = 0)
        {
            try
            {
                if (id == 0)
                {
                    this.AddAlertDanger("Ocorreu um erro ao deletar este Fornecedor.");
                    return RedirectToAction(nameof(Index));
                }

                var empresa = await _servico.Find(id);
                if (empresa != null)
                {
                    _servico.Excluir(empresa);
                    await _servico.SaveChangesAsync();
                    this.AddAlertSuccess("Fornecedor removido com sucesso.");
                    return RedirectToAction(nameof(Index));
                }

                this.AddAlertDanger("Fornecedor não encontrada.");
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception e)
            {

                throw e;
            }
          
        }

        public async Task<JsonResult> GetEmpresas(string search)
        {
            var empresas = await _servicoEmpresa.BuscarEmpresasAutoComplete(search);

            var modifiedData = empresas.Select(x => new
            {
                id = x.Id,
                text = x.NomeFantasia
            });
            return Json(modifiedData);
        }

        public async Task<JsonResult> GetEmpresa(long id)
        {
            if (id == 0)
            {
                return Json(null);
            }
            var empresa = await _servicoEmpresa.Find(id);

            var modifiedData = new
            {
                id = empresa.Id,
                text = empresa.NomeFantasia
            };

            return Json(modifiedData);
        }
    }
}