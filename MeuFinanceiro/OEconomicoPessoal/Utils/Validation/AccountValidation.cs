
using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Enums;
using System;
using System.Collections.Generic;
namespace OEconomicoPessoal.Utils.Validation
{
    public class AccountValidation : BaseValidation
    {
        public void ValidarAccountIsValido(Account account, EAcaoFuncionalidade acao = EAcaoFuncionalidade.Salvar)
        {
            List<string> mensagensValidation = new List<string>();
            if (acao == EAcaoFuncionalidade.Atualizar || acao == EAcaoFuncionalidade.Excluir)
            {
                if (string.IsNullOrEmpty(account.Id.ToString()))
                    mensagensValidation.Add("O código está inválido.");
            }

            if (string.IsNullOrEmpty(account.Email)
                  || account.Email.Trim().Length == 0
                  || !account.Email.Contains("@"))
            {
                mensagensValidation.Add("O e-mail está inválido.");
            }
            if (string.IsNullOrEmpty(account.Senha))
                mensagensValidation.Add("A senha está inválido.");
            if (string.IsNullOrEmpty(account.Telefone))
                mensagensValidation.Add("O telefone está inválido.");
            if (string.IsNullOrEmpty(account.Cpf))
                mensagensValidation.Add("O CPF ou RG está inválido.");
            if (account.DataNascimento >= DateTime.Now)
                mensagensValidation.Add("A data de nascimento está inválido.");

            if (mensagensValidation.Count > 0)
                throw new Exception(string.Join(" | ", mensagensValidation));
        }

        public void ValidarAccountSeUsuarioJaExiste(Account account)
        {
            List<string> mensagensValidation = new List<string>();

            if (account != null)
            {
                if (!string.IsNullOrEmpty(account.Email.Trim().ToString()))
                {
                    mensagensValidation.Add("O e-mail já está cadastrado. Use a opção recuperar senha ou digite outro e-mail");
                }
            }

            if (mensagensValidation.Count > 0)
                throw new Exception(string.Join(" | ", mensagensValidation));
        }

        public void ValidarSeSenhaIgualConfimarcaoSenha(string senha, string confirmacao)
        {
            List<string> mensagensValidation = new List<string>();

            if (!string.IsNullOrEmpty(senha) || !string.IsNullOrEmpty(confirmacao))
            {
                if(!senha.Equals(confirmacao))
                {
                    mensagensValidation.Add("A senha não confere com a confirmação de senha.");
                }
            }

            if (mensagensValidation.Count > 0)
            {
                throw new Exception(string.Join(" | ", mensagensValidation));
            }                         
        }

        internal void ValidarRecuperarSenhaNovaSenha(string email, string senha, string confirmeSenha)
        {
            List<string> mensagensValidation = new List<string>();

            if (string.IsNullOrEmpty(email))
            {
                mensagensValidation.Add("E-mail não encontrado, tente novamente.");                
            }
            if (string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmeSenha))
            {
                mensagensValidation.Add("Senha inválida.");                
            }
            if (!string.IsNullOrEmpty(senha) || !string.IsNullOrEmpty(confirmeSenha))
            {
                if (!senha.Equals(confirmeSenha))
                {
                    mensagensValidation.Add("As senhas estão diferentes.");
                }
            }

            if (mensagensValidation.Count > 0)
                throw new Exception(string.Join(" | ", mensagensValidation));
        }
    }
}