using System;

namespace OEconomicoPessoal.Utils.Validation
{
    public abstract class BaseValidation
    {
        public void IsNullOrEmpty(string param)
        {
            if (string.IsNullOrEmpty(param))
                throw new Exception("OPS... Valor nulo não é permitido.");
        }

        public void IsNullOrEmpty(string param, string param1)
        {
            if (string.IsNullOrEmpty(param))
                throw new Exception("OPS... Valor nulo não é permitido.");
            if (string.IsNullOrEmpty(param1))
                throw new Exception("OPS... Valor nulo não é permitido.");
        }

        public void IsNullOrEmpty(string param, string param1, string param2)
        {
            if (string.IsNullOrEmpty(param))
                throw new Exception("OPS... Valor nulo não é permitido.");
            if (string.IsNullOrEmpty(param1))
                throw new Exception("OPS... Valor nulo não é permitido.");
            if (string.IsNullOrEmpty(param2))
                throw new Exception("OPS... Valor nulo não é permitido.");
        }

        public void IsNullOrEmpty(string paran, string campo, string param1, string param2)
        {
            if (string.IsNullOrEmpty(paran))
                throw new Exception(String.Format("OPS... O campo {0} não pode ser nulo ou vazio.", campo));
        }

        //public void IsNullOrEmpty(string[] paran, string[] campo)
        //{
        //    for (int i = 0; i < paran.Length; i++)
        //    {
        //        IsNullOrEmpty(paran[i],"");
        //    }           
        //}

        public void IsNullOrEmpty(object objeto)
        {
            if (objeto == null)
                throw new Exception("OPS... O objeto não pode ser nulo ou vazio.");
        }


        /// <summary>
        /// Validar se determinado campo é um valor menor que ZERO
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="campo"></param>
        public void IsValorMenorQueZero(decimal valor, string campo)
        {
            if (valor <= 0)
            {
                throw new Exception(string.Format("OPS... O campo {0} está inválido.", campo));
            }
        }

        public bool IsValorMenorQueZero(decimal valor)
        {
            if (valor <= 0) { return true; }
            else { return false; }
        }
    }
}