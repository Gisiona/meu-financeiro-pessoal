using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OEconomicoPessoal.Entidades
{
    [Table("Despesas")]
    public class Despesa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public byte[] Arquivo { get; set; }
        public bool IsParcelado { get; set; }
        public int QtdeParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public bool IsAtivo { get; set; }

        public virtual TipoPagamento TipoPagamentos { get; set; }
        public virtual TipoDespesa TipoDespesas { get; set; }
        public virtual Account Accounts { get; set; }
        public virtual Conta Contas { get; set; }

        public int AccountId { get; set; }
        public int TipoDespesaId { get; set; }
        public int TipoPagamentoId { get; set; }
        public int ContaId { get; set; }

        public Despesa()
        {
            this.IsAtivo = true;
            this.DataCadastro = DateTime.Now;
        }
    }
}