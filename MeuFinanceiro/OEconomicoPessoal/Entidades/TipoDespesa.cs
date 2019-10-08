using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OEconomicoPessoal.Entidades
{
    [Table("TipoDespesas")]
    public class TipoDespesa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public Boolean IsAtivo { get; set; }
        public virtual Account Accounts { get; set; }
        public int AccountId { get; set; }

        public TipoDespesa()
        {
        }
    }
}