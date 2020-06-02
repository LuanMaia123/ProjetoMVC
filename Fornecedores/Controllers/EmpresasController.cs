using Dominio.Modelos;
using Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fornecedores.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IServicoEmpresa _servico;

        public EmpresasController(IServicoEmpresa servico)
        {
            _servico = servico;
        }

        public async Task<IActionResult> Index([Bind("Nome ,Cnpj,Cpf, Data, CurrentPage")] EmpresaListModel empresaListModel)
        {
            return View(await _servico.BuscarEmpresas(empresaListModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Uf,NomeFantasia,Cnpj,Id")] EmpresaModel empresa)
        {
            if (ModelState.IsValid)
            {
                if (empresa.Id == 0)
                {
                    _servico.Incluir(empresa);
                    this.AddAlertSuccess("Empresa incluida com sucesso.");
                }
                else
                {
                    _servico.Alterar(empresa);
                    this.AddAlertSuccess("Empresa alterada com sucesso.");
                }


                await _servico.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        public async Task<IActionResult> AddOrEdit(long id = 0)
        {
            if (id == 0)
            {
                return View(new EmpresaModel());
            }
            else
            {
                return View(await _servico.Find(id));
            }
        }

        public async Task<IActionResult> Delete(long id = 0)
        {
            if (id == 0)
            {
                this.AddAlertDanger("Ocorreu um erro ao deletar esta empresa.");
                return RedirectToAction(nameof(Index));
            }

            var empresa = await _servico.Find(id);
            if (empresa != null)
            {
                _servico.Excluir(empresa);
                await _servico.SaveChangesAsync();
                this.AddAlertSuccess("Empresa removida com sucesso.");
                return RedirectToAction(nameof(Index));
            }

            this.AddAlertDanger("Empresa não encontrada.");
            return RedirectToAction(nameof(Index));
        }
    }
}