using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OEconomicoPessoal.Entidades
{
    [Table("Contas")]
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IsAtivo { get; set; }
        public virtual Account Accounts { get; set; }
        public int AccountId { get; set; }

        public Conta()
        {
            this.IsAtivo = true;
            this.DataCadastro = DateTime.Now;
        }
    }
}