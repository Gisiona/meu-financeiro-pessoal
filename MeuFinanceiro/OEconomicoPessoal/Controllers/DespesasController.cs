using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Models.ViewModel;
using OEconomicoPessoal.Repositorios;
using OEconomicoPessoal.Utils;
using OEconomicoPessoal.Utils.Conversor;
using System;
using System.Web;
using System.Web.Mvc;

namespace OEconomicoPessoal.Controllers
{
    [Filtros.FiltrosHelpers]
    public class DespesasController : Controller
    {
        private readonly DespesaRepositorio _repositorio;

        public DespesasController()
        {
            this._repositorio = new DespesaRepositorio();
        }


        // GET: Despesa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Despesa
        public ActionResult NovaDespesa()
        {
            InicializarDadosTelaNovaDespesa();
            return View();
        }

        private void InicializarDadosTelaNovaDespesa()
        {
            ViewBag.contas = new ContaRepositorio().ListarTodasContasPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado());
            ViewBag.tipodespesa = new DespesaRepositorio().ListarTipoDespesasPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado());
            ViewBag.formapagamento = new DespesaRepositorio().ListarFormaPagamentoPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado());
        }
        

        // POST: Despesa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaDespesa(FormCollection form, HttpPostedFileBase file)
        {
            try
            {
                Despesa _despesa = new Despesa
                {
                    Valor = Convert.ToDecimal(form["valor"]),
                    AccountId = AccountRepositorio.RetornaIdUsuarioLogado(),
                    ContaId = Convert.ToInt32(form["conta"]),
                    TipoDespesaId = Convert.ToInt32(form["tipodespesa"]),
                    TipoPagamentoId = Convert.ToInt32(form["pagamento"]),
                    DataCadastro = Convert.ToDateTime(form["data"]),
                    Descricao = Convert.ToString(form["descricao"]),
                    Arquivo = file != null ? Conversores.ConverToBytes(file) : null,
                    IsParcelado = false,
                    QtdeParcela = 0,
                    ValorParcela = 0,
                    IsAtivo = true
                };

                _repositorio.Salvar(_despesa);                
                @ViewBag.sucesso = "Despesa criada com sucesso.";
                InicializarDadosTelaNovaDespesa();
                return View();
            }
            catch (Exception e)
            {
                @ViewBag.erro = e.Message;
                return View();
            }
        }

        //GET MinhasDespesas
        public ActionResult MinhasDespesas()
        {
            DespesasViewModel vm = new DespesasViewModel()
            {
                GetDespesas = _repositorio.ListarTodasDespesasPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado())
            };
            return View(vm);
        }


        public ActionResult Tipodespesas()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tipodespesas(FormCollection form)
        {
            try
            {
                TipoDespesa _tipoDespesa = new TipoDespesa
                {
                    AccountId = AccountRepositorio.RetornaIdUsuarioLogado(),
                    Descricao = Convert.ToString(form["descricao"]),
                    DataCadastro = DateTime.Now,
                    IsAtivo = true
                };

                _repositorio.SalvarTipoDespesa(_tipoDespesa);
                @ViewBag.sucesso = "Tipo despesa criada com sucesso.";
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