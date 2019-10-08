using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Enums;
using System;
using System.Collections.Generic;

namespace OEconomicoPessoal.Utils.Validation
{
    public class DespesaValidation: BaseValidation
    {
        public void ValidarDespesaIsValido(Despesa despesa, EAcaoFuncionalidade acao = EAcaoFuncionalidade.Salvar)
        {
            List<string> mensagensValidation = new List<string>();
            if (acao == EAcaoFuncionalidade.Atualizar || acao == EAcaoFuncionalidade.Excluir)
            {
                if (string.IsNullOrEmpty(despesa.Id.ToString()))
                    mensagensValidation.Add("O código está inválido.");
            }

            if (string.IsNullOrEmpty(despesa.Descricao)
                  || despesa.Descricao.Trim().Length == 0)
            {
                mensagensValidation.Add("A descrição da despesa está inválido.");
            }
            if (IsValorMenorQueZero(despesa.Valor))
                mensagensValidation.Add("O valor da despesa está inválido.");

            if (mensagensValidation.Count > 0)
                throw new Exception(string.Join(" | ", mensagensValidation));
        }
    }
}