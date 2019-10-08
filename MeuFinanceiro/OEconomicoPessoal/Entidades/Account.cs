using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OEconomicoPessoal.Entidades
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public Guid ChaveIdentificador { get; set; }
        public bool IsAtivo { get; set; }

        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmarSenha")]
        public string ConfirmarSenha { get; set; }

        public DateTime DataCadastro { get; set; }
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Index(IsUnique = true)] 
        public string Email { get; set; }

        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Lembrar usuário e senha?")]
        public bool RememberMe { get; set; }
        public DateTime DataAtualizacao { get; set; }

        //public ICollection<TipoDespesa> TipoDespesas { get; set; }
        //public ICollection<TipoReceita> TipoReceitas { get; set; }
        //public ICollection<TipoPagamento> TipoPagamentos { get; set; }
        //public ICollection<Conta> Contas { get; set; }
        //public ICollection<Receita> Receitas { get; set; }
        //public ICollection<Despesa> Despesas { get; set; }


        public Account()
        {
            //this.TipoDespesas = new List<TipoDespesa>();
            //this.TipoReceitas = new List<TipoReceita>();
            //this.TipoPagamentos = new List<TipoPagamento>();
            //this.Contas = new List<Conta>();
            //this.Receitas = new List<Receita>();
            //this.Despesas = new List<Despesa>();
        }
    }
}