using OEconomicoPessoal.Dao;
using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace OEconomicoPessoal.Infra.DaoEF
{
    public class AccountDao : IAccount, IDisposable
    {

        private readonly OEconomicoContext _context;

        public AccountDao()
        {
            _context = new OEconomicoContext();
        }


        public Entidades.Account ConsultarUsuarioPorEmailSenha(Entidades.Account entity)
        {
            try
            {
                return _context.Accounts.Find(entity.Id);
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar usuário.");
            }
        }

        public void Salvar(Entidades.Account entity)
        {
            try
            {
                entity.DataCadastro = DateTime.Now;
                entity.ChaveIdentificador = Guid.NewGuid();
                entity.RememberMe = true;
                entity.IsAtivo = true;
                _context.Accounts.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao criar novo usuário.");
            }
        }

        public void Atualizar(Entidades.Account entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao atualizar usuário.");
            }
        }

        public void Excluir(Entidades.Account entity)
        {
            try
            {
                _context.Accounts.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao excluir usuário.");
            }
        }

        public Account ConsultarPorId(int id)
        {
            try
            {
                return _context.Accounts.Find(id);
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar usuário.");
            }
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("OPS... Erro ao salvar dados.");
            }
        }


        /// <summary>
        /// Autenticar o usuário na aplicação
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public Account AutenticarUsuario(string email, string senha)
        {
            try
            {
                return _context.Accounts.Where(x => x.Email == email && x.Senha == senha).SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Consultar o usuário através do IdAccount passado por parametro
        /// </summary>
        /// <param name="IdAccount"></param>
        /// <returns></returns>
        public Account RecuperaUsuarioPorID(int IdAccount)
        {
            try
            {
                var usuario = _context.Accounts.Where(u => u.Id == IdAccount).SingleOrDefault();
                return usuario;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Account RecuperaUsuarioPorEmail(string email)
        {
            try
            {
                var usuario = _context.Accounts.Where(u => u.Email == email).SingleOrDefault();
                return usuario;
            }
            catch (Exception)
            {
                return null;
            }
        }
        

        public void CriarNovaSenha(string email, string hashcode, string senha, string confirmeSenha)
        {
            throw new NotImplementedException();
        }

        internal void AlterarSenha(Account usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}