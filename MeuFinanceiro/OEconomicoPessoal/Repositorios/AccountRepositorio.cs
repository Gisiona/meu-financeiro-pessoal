using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Infra.DaoEF;
using OEconomicoPessoal.Interfaces;
using OEconomicoPessoal.Utils;
using OEconomicoPessoal.Utils.Constantes;
using OEconomicoPessoal.Utils.Validation;
using System;
using System.Web;

namespace OEconomicoPessoal.Repositorios
{
    public class AccountRepositorio: IAccount
    {
        private readonly AccountDao _dao;
        private readonly AccountValidation _validation;

        public AccountRepositorio()
        {
            this._validation = new AccountValidation();
            this._dao = new AccountDao();
        }

        public Account ConsultarUsuarioPorEmailSenha(Entidades.Account entity)
        {
            _validation.ValidarAccountIsValido(entity);
            return _dao.ConsultarUsuarioPorEmailSenha(entity);
        }

        public void Salvar(Entidades.Account entity)
        {
            _validation.ValidarAccountSeUsuarioJaExiste(RecuperaUsuarioPorEmail(entity.Email));
            _validation.ValidarAccountIsValido(entity, Enums.EAcaoFuncionalidade.Salvar);
            _validation.ValidarSeSenhaIgualConfimarcaoSenha(entity.Senha, entity.ConfirmarSenha);
            _dao.Salvar(entity);
            EmailRepositorio.EnviarEmailCadastroNovoUsuario(entity);
        }

        public string Salvar(Entidades.Account entity, string t = null)
        {
            _validation.ValidarAccountSeUsuarioJaExiste(RecuperaUsuarioPorEmail(entity.Email));
            _validation.ValidarAccountIsValido(entity, Enums.EAcaoFuncionalidade.Salvar);
            entity.Senha = Criptografia.Criptografar(entity.Senha);
            entity.ConfirmarSenha = Criptografia.Criptografar(entity.ConfirmarSenha);
            _validation.ValidarSeSenhaIgualConfimarcaoSenha(entity.Senha, entity.ConfirmarSenha);
            entity.Telefone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            entity.Cpf.Replace(".", "").Replace("/", "").Replace("-","");
            //entity.Email = Criptografia.Criptografar(entity.Email).Substring(1,4000);
            _dao.Salvar(entity);
            return EmailRepositorio.EnviarEmailCadastroNovoUsuario(entity);
        }

        public void Atualizar(Entidades.Account entity)
        {
            _validation.ValidarAccountIsValido(entity, Enums.EAcaoFuncionalidade.Atualizar);
            _validation.ValidarSeSenhaIgualConfimarcaoSenha(entity.Senha, entity.ConfirmarSenha);
            entity.Id = RetornaIdUsuarioLogado();
            _dao.Atualizar(entity);
        }

        public void Excluir(Entidades.Account entity)
        {
            var account = ConsultarPorId(entity.Id);
            _validation.IsNullOrEmpty(account);
            _dao.Excluir(entity);
        }

        public Entidades.Account ConsultarPorId(int id)
        {
            _validation.IsNullOrEmpty(id.ToString());
            return _dao.ConsultarPorId(id);
        }

        public void SaveChanges()
        {
            throw new Exception("OPS... Este método não possui implementação.");
        }


        public bool ConsultarPorEmailSenha(string email, string senha)
        {
            _validation.IsNullOrEmpty(email, senha);
            var retorno = _dao.ConsultarUsuarioPorEmailSenha(new Account { Email = email, Senha = senha });
            return true;
        }


        /// <summary>
        /// Autenticar o usuário na aplicação
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool AutenticarUsuario(string email, string senha)
        {
            //var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "sha1");
            try
            {
                //var t = Criptografia.Criptografar(senha);
                var queryAutenticaUsuarios = _dao.AutenticarUsuario(email, Criptografia.Criptografar(senha));
                if (queryAutenticaUsuarios == null)
                {
                    return false;
                }
                else
                {
                    CookiesAutenticacao.RegistraCookieAutenticacao(queryAutenticaUsuarios.Id, queryAutenticaUsuarios.Email, queryAutenticaUsuarios.Senha);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Recumpera o usuário que está logado na aplicação naquele computador
        /// </summary>
        /// <returns></returns>
        public Account VerificaSeOUsuarioEstaLogado()
        {
            var usuario = HttpContext.Current.Request.Cookies[Constante.CAccount.USUARIOLOGADO];
            if (usuario == null)
            {
                return null;
            }
            else
            {
                int IdAccount = Convert.ToInt32(Criptografia.Descriptografar(""));
                return RecuperaUsuarioPorID(IdAccount);
            }
        }

        /// <summary>
        /// Sair do sistema: Remove o usuário logado do cookie.
        /// </summary>
        /// <returns></returns>
        public static bool SairDoSistema()
        {
            try
            {
                var Cookie = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
                Cookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna o IdAccount do usuário logado na aplicação
        /// </summary>
        /// <returns></returns>
        public static int RetornaIdUsuarioLogado()
        {
            var Usuario = HttpContext.Current.Request.Cookies[Constante.CAccount.USUARIOLOGADO];

            if (Usuario == null)
            {
                return 0;
            }
            else
            {
                int IdAccount = Convert.ToInt32(Criptografia.Descriptografar(Usuario.Values["IdAccount"]));
                return IdAccount;
            }
        }


        Account IAccount.AutenticarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }


        public Account RecuperaUsuarioPorID(int IdAccount)
        {
            return _dao.RecuperaUsuarioPorID(IdAccount);
        }

        public Account RecuperaUsuarioPorEmail(string email)
        {
            _validation.IsNullOrEmpty(email);
            return _dao.RecuperaUsuarioPorEmail(email);
        }


        public string RecuperarSenha(string email)
        {
            _validation.IsNullOrEmpty(email);
            Account usuario = _dao.RecuperaUsuarioPorEmail(email);
            string retorno = string.Empty;

            if(usuario != null)
            {
                retorno = EmailRepositorio.EnviarEmailRecuperacaoSenha(usuario);
            }
            else
            {
                throw new Exception("Não foi localizado nenhum usuário para o e-mail informado. Tente criar um novo cadastro.");
            }
            return retorno;
        }

        public void CriarNovaSenha(string email, string hashcode, string senha, string confirmeSenha)
        {
            try
            {
                _validation.ValidarRecuperarSenhaNovaSenha(email, senha, confirmeSenha);
                var usuario = _dao.RecuperaUsuarioPorEmail(email);
                
                if(usuario != null)
                {
                    if (usuario.Senha.Equals(hashcode))
                    {
                        usuario.Senha = Criptografia.Criptografar(senha);
                        usuario.Telefone = usuario.Telefone == null ? "00-00000-0000" : usuario.Telefone;
                        usuario.Cpf = usuario.Cpf == null ? "000.000.000-00" : usuario.Cpf;
                        usuario.ConfirmarSenha = Criptografia.Criptografar(confirmeSenha);
                        usuario.DataAtualizacao = DateTime.Now;
                        _dao.AlterarSenha(usuario);
                    }
                    else
                    {
                        throw new Exception("Ops...O código gerado para alteração de senha não é mais válido. Tente recuperar a senha novamente.");
                    }                    
                }
                else
                {
                    throw new Exception("Ops...Não foi possível alterar a senha. Tente novamente mais tarde.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}