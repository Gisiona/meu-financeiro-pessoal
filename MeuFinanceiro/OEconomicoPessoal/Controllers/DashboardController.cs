using OEconomicoPessoal.Models.ViewModel;
using OEconomicoPessoal.Repositorios;
using System;
using System.Web.Mvc;

namespace OEconomicoPessoal.Controllers
{
    [Filtros.FiltrosHelpers]
    public class DashboardController : Controller
    {
        private readonly DashboardRepositorio _repositorio;

        public DashboardController ()
	    {
            _repositorio = new DashboardRepositorio();
	    }                

        public ActionResult Index()
        {
            try
            {
                DashboardViewModel vm = new DashboardViewModel()
                {
                    GetContas = _repositorio.GetContas(AccountRepositorio.RetornaIdUsuarioLogado()),
                    GetDespesas = _repositorio.GetDespesas(AccountRepositorio.RetornaIdUsuarioLogado()),
                    GetReceitas = _repositorio.GetReceitas(AccountRepositorio.RetornaIdUsuarioLogado()),
                    TotalAcumuladoContas = _repositorio.TotalAcumuladoContas(AccountRepositorio.RetornaIdUsuarioLogado()),
                    TotalDespesasMes = _repositorio.TotalDespesasMes(AccountRepositorio.RetornaIdUsuarioLogado()),
                    TotalReceitasMes = _repositorio.TotalReceitasMes(AccountRepositorio.RetornaIdUsuarioLogado())
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                @ViewBag.erro = ex.Message;
            }
            return View();
        }
    }
}