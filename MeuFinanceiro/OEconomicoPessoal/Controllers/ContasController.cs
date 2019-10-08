using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Models.ViewModel;
using OEconomicoPessoal.Repositorios;
using System;
using System.Web.Mvc;

namespace OEconomicoPessoal.Controllers
{
    [Filtros.FiltrosHelpers]
    public class ContasController : Controller
    {
        private readonly ContaRepositorio _repositorio;
        public ContasController()
        {
            this._repositorio = new ContaRepositorio();
        }

        // GET: Contas
        public ActionResult Minhascontas()
        {
            ContasViewModel vm = new ContasViewModel()
            {
                GetContas = _repositorio.ListarTodasContasPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado())
            };
            return View(vm);
        }

        public ActionResult NovaConta()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaConta(FormCollection form)
        {
            try
            {
                Conta _conta = new Conta
                {
                    AccountId = AccountRepositorio.RetornaIdUsuarioLogado(),
                    Descricao = Convert.ToString(form["descricao"]),
                    Valor = Convert.ToDecimal(form["valor"]),
                    DataCadastro = DateTime.Now,
                    IsAtivo = true
                };

                _repositorio.Salvar(_conta);
                @ViewBag.sucesso = "Conta criada com sucesso.";
                return View();
            }
            catch (Exception e)
            {
                @ViewBag.erro = e.Message;
                return View();
            }
        }
    }
}