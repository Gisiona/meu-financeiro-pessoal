using OEconomicoPessoal.Utils.Constantes;
using System;
using System.Web;

namespace OEconomicoPessoal.Utils
{
    public class CookiesAutenticacao
    {
        public static void RegistraCookieAutenticacao(int IdAccount, string email, string senha)
        {
            //Criando um objeto cookie
            HttpCookie UserCookie = new HttpCookie(Constante.CAccount.USUARIOLOGADO);

            //Setando o ID do usuário no cookie
            UserCookie.Values["IdAccount"] = Criptografia.Criptografar(IdAccount.ToString());

            UserCookie.Values["StatusLogon"] = Criptografia.Criptografar("1"); // 1 logado.
            UserCookie.Values["Email"] = Criptografia.Criptografar(email);
            UserCookie.Values["Senha"] = Criptografia.Criptografar(senha);

            //Definindo o prazo de vida do cookie
            UserCookie.Expires = DateTime.Now.AddMinutes(10);

            //Adicionando o cookie no contexto da aplicação
            HttpContext.Current.Response.Cookies.Add(UserCookie);
        }

        public static void RemoveCookieAutenticacao()
        {
            if (HttpContext.Current.Request.Cookies[Constante.CAccount.USUARIOLOGADO] != null)
            {
                string[] myCookies = HttpContext.Current.Request.Cookies.AllKeys;
                
                //HttpContext.Current.Request.Cookies[Constantes.CAccount.USUARIOLOGADO].Values;
                if (myCookies != null)
                {
                    foreach (string cookie in myCookies)
                    {
                        HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-2);
                        cookie.Remove(0);
                    }
                }
            }
        }
    }
}