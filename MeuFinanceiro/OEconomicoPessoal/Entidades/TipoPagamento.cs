using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OEconomicoPessoal.Entidades
{
    [Table("TipoPagamentos")]
    public class TipoPagamento
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IsAtivo { get; set; }
        public virtual Account Accounts { get; set; }

        public int AccountId { get; set; }


        public TipoPagamento()
        {
        }
    }
}