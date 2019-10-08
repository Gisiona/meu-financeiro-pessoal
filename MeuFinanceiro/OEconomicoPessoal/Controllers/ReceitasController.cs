using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Models.ViewModel;
using OEconomicoPessoal.Repositorios;
using OEconomicoPessoal.Utils.Conversor;
using System;
using System.Web;
using System.Web.Mvc;

namespace OEconomicoPessoal.Controllers
{
    [Filtros.FiltrosHelpers]
    public class ReceitasController : Controller
    {
        private readonly ReceitaRepositorio _repositorio;
        public ReceitasController()
        {
            this._repositorio = new ReceitaRepositorio();
        }

        private void InicializarDadosTelaNovaDespesa()
        {
            ViewBag.contas = new ContaRepositorio().ListarTodasContasPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado());
            ViewBag.tiporeceitas = new ReceitaRepositorio().ListarTipoReceitaPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado());
            ViewBag.formapagamento = new DespesaRepositorio().ListarFormaPagamentoPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado());
        }

        // GET: Receitas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Receitas
        public ActionResult NovaReceita()
        {
            InicializarDadosTelaNovaDespesa();
            return View();
        }

        // GET: Receitas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaReceita(FormCollection form, HttpPostedFileBase file)
        {
            try
            {
                Receita _receita = new Receita
                {
                    Valor = Convert.ToDecimal(form["valor"]),
                    DataCadastro = Convert.ToDateTime(form["data"]),
                    Descricao = Convert.ToString(form["descricao"]),
                    Arquivo = file != null ? Conversores.ConverToBytes(file) : null,
                    AccountId = AccountRepositorio.RetornaIdUsuarioLogado(),
                    ContaId = Convert.ToInt32(form["conta"]),
                    TipoReceitaId = Convert.ToInt32(form["tiporeceita"]),
                    TipoPagamentoId = Convert.ToInt32(form["pagamento"]),
                    IsAtivo = true,
                };

                _repositorio.Salvar(_receita);
                @ViewBag.sucesso = "Receita criada com sucesso.";
                InicializarDadosTelaNovaDespesa();
                return View();
            }
            catch (Exception e)
            {
                @ViewBag.erro = e.Message;
                return View();
            }
        }

        public ActionResult Minhasreceitas()
        {
            ReceitasViewModel vm = new ReceitasViewModel()
            {
                GetReceitas = _repositorio.ListarTodasReceitasPorUsuario(AccountRepositorio.RetornaIdUsuarioLogado())
            };
            return View(vm);
        }

        public ActionResult Tiporeceitas()
        {          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tiporeceitas(FormCollection form)
        {
            try
            {
                TipoReceita _tipoReceita = new TipoReceita
                {
                    AccountId = AccountRepositorio.RetornaIdUsuarioLogado(),
                    Descricao = Convert.ToString(form["descricao"]),
                    DataCadastro = DateTime.Now,
                    IsAtivo = true
                };

                _repositorio.SalvarTipoReceita(_tipoReceita);
                @ViewBag.sucesso = "Tipo receita criada com sucesso.";
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