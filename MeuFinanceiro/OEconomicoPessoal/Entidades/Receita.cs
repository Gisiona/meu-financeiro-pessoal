using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OEconomicoPessoal.Entidades
{
    [Table("Receitas")]
    public class Receita
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IsAtivo { get; set; }
        public byte[] Arquivo { get; set; }

        public virtual TipoReceita TipoReceitas { get; set; }
        public virtual TipoPagamento TipoPagamentos { get; set; }
        public virtual Account Accounts { get; set; }
        public virtual Conta Contas { get; set; }

        public int AccountId { get; set; }
        public int TipoReceitaId { get; set; }
        public int TipoPagamentoId { get; set; }
        public int ContaId { get; set; }

        public Receita()
        {
            this.IsAtivo = true;
            this.DataCadastro = DateTime.Now;
        }

    }
}