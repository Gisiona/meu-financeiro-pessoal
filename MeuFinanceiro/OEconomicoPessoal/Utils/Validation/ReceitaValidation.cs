using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEconomicoPessoal.Utils.Validation
{
    public class ReceitaValidation : BaseValidation
    {
        public void ValidarReceitaIsValido(Receita receita, EAcaoFuncionalidade acao = EAcaoFuncionalidade.Salvar)
        {
            List<string> mensagensValidation = new List<string>();
            if (acao == EAcaoFuncionalidade.Atualizar || acao == EAcaoFuncionalidade.Excluir)
            {
                if (string.IsNullOrEmpty(receita.Id.ToString()))
                    mensagensValidation.Add("O código está inválido.");
            }

            if (string.IsNullOrEmpty(receita.Descricao)
                  || receita.Descricao.Trim().Length == 0)
            {
                mensagensValidation.Add("A descrição da despesa está inválido.");
            }
            if (IsValorMenorQueZero(receita.Valor))
                mensagensValidation.Add("O valor da despesa está inválido.");

            if (mensagensValidation.Count > 0)
                throw new Exception(string.Join(" | ", mensagensValidation));
        }
    }
}