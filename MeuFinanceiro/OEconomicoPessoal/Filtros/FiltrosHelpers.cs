using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Repositorios;
using OEconomicoPessoal.Utils;
using OEconomicoPessoal.Utils.Constantes;
using System;
using System.Web.Mvc;

namespace OEconomicoPessoal.Filtros
{
    public class FiltrosHelpers : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = filterContext.ActionDescriptor.ActionName;
            if (Controller != "account" || Action != "login")
            {
                if (GetUsuarioLogado() == null)
                {
                    filterContext.RequestContext.HttpContext.Response.
                    Redirect("/account/login?returnUrl=" + filterContext.HttpContext.Request.Url.LocalPath);
                }
            }
            object ultimoError = filterContext.HttpContext.Server.GetLastError();
        }

        public Account GetUsuarioLogado()
        {
            try
            {
                var _account = System.Web.HttpContext.Current.Request.Cookies[Constante.CAccount.USUARIOLOGADO];
                if (_account == null)
                {
                    return null;
                }
                else
                {
                    var IdUsuario = Convert.ToInt32(Criptografia.Descriptografar(_account.Values["IdAccount"]));
                    AccountRepositorio bo = new AccountRepositorio();
                    return bo.ConsultarPorId(IdUsuario);
                }
            }
            catch
            {
                return null;
            }
        }


        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }
    }
}