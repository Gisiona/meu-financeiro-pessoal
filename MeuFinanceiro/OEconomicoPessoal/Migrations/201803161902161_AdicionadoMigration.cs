namespace OEconomicoPessoal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAtivo = c.Boolean(nullable: false,defaultValue:true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Senha = c.String(nullable: false, maxLength: 20),
                        DataCadastro = c.DateTime(nullable: false,defaultValue:DateTime.Now),
                        Cpf = c.String(nullable: true, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 200),
                        Telefone = c.String(nullable: true, maxLength: 20),
                        DataNascimento = c.DateTime(nullable: true),
                        LembrarSenha = c.Boolean(nullable: false,defaultValue:true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2,defaultValue:0),
                        DataCadastro = c.DateTime(nullable: false,defaultValue:DateTime.Now),
                        IsAtivo = c.Boolean(nullable: false,defaultValue:true),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Despesas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue:0),
                        DataCadastro = c.DateTime(nullable: false,defaultValue:DateTime.Now),
                        AnexoNotaFiscal = c.Binary(nullable: false, storeType: "image"),
                        IsParcelado = c.Boolean(nullable: false,defaultValue:false),
                        QtdeParcela = c.Int(nullable: false,defaultValue:0),
                        ValorParcela = c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue:0),
                        IsAtivo = c.Boolean(nullable: false,defaultValue:true),
                        AccountId = c.Int(nullable: false),
                        TipoDespesaId = c.Int(nullable: false),
                        TipoPagamentoId = c.Int(nullable: false),
                        ContaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Contas", t => t.ContaId)
                .ForeignKey("dbo.TipoDespesas", t => t.TipoDespesaId)
                .ForeignKey("dbo.TipoPagamentos", t => t.TipoPagamentoId)
                .Index(t => t.AccountId)
                .Index(t => t.TipoDespesaId)
                .Index(t => t.TipoPagamentoId)
                .Index(t => t.ContaId);
            
            CreateTable(
                "dbo.TipoDespesas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        DataCadastro = c.DateTime(nullable: false, defaultValue:DateTime.Now),
                        IsAtivo = c.Boolean(nullable: false,defaultValue:true),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.TipoPagamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        DataCadastro = c.DateTime(nullable: false, defaultValue:DateTime.Now),
                        IsAtivo = c.Boolean(nullable: false, defaultValue:true),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Receitas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Valor = c.Decimal(nullable: true, precision: 18, scale: 2, defaultValue:0),
                        DataCadastro = c.DateTime(nullable: true, defaultValue:DateTime.Now),
                        IsAtivo = c.Boolean(nullable: false,defaultValue:true),
                        AnexoNotaFiscal = c.Binary(nullable: true, storeType: "image"),
                        AccountId = c.Int(nullable: false),
                        TipoReceitaId = c.Int(nullable: false),
                        TipoPagamentoId = c.Int(nullable: false),
                        ContaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Contas", t => t.ContaId)
                .ForeignKey("dbo.TipoPagamentos", t => t.TipoPagamentoId)
                .ForeignKey("dbo.TipoReceitas", t => t.TipoReceitaId)
                .Index(t => t.AccountId)
                .Index(t => t.TipoReceitaId)
                .Index(t => t.TipoPagamentoId)
                .Index(t => t.ContaId);
            
            CreateTable(
                "dbo.TipoReceitas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        DataCadastro = c.DateTime(nullable: false, defaultValue:DateTime.Now),
                        IsAtivo = c.Boolean(nullable: false, defaultValue:true),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receitas", "TipoReceitaId", "dbo.TipoReceitas");
            DropForeignKey("dbo.TipoReceitas", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Receitas", "TipoPagamentoId", "dbo.TipoPagamentos");
            DropForeignKey("dbo.Receitas", "ContaId", "dbo.Contas");
            DropForeignKey("dbo.Receitas", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Despesas", "TipoPagamentoId", "dbo.TipoPagamentos");
            DropForeignKey("dbo.TipoPagamentos", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Despesas", "TipoDespesaId", "dbo.TipoDespesas");
            DropForeignKey("dbo.TipoDespesas", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Despesas", "ContaId", "dbo.Contas");
            DropForeignKey("dbo.Despesas", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Contas", "AccountId", "dbo.Accounts");
            DropIndex("dbo.TipoReceitas", new[] { "AccountId" });
            DropIndex("dbo.Receitas", new[] { "ContaId" });
            DropIndex("dbo.Receitas", new[] { "TipoPagamentoId" });
            DropIndex("dbo.Receitas", new[] { "TipoReceitaId" });
            DropIndex("dbo.Receitas", new[] { "AccountId" });
            DropIndex("dbo.TipoPagamentos", new[] { "AccountId" });
            DropIndex("dbo.TipoDespesas", new[] { "AccountId" });
            DropIndex("dbo.Despesas", new[] { "ContaId" });
            DropIndex("dbo.Despesas", new[] { "TipoPagamentoId" });
            DropIndex("dbo.Despesas", new[] { "TipoDespesaId" });
            DropIndex("dbo.Despesas", new[] { "AccountId" });
            DropIndex("dbo.Contas", new[] { "AccountId" });
            DropTable("dbo.TipoReceitas");
            DropTable("dbo.Receitas");
            DropTable("dbo.TipoPagamentos");
            DropTable("dbo.TipoDespesas");
            DropTable("dbo.Despesas");
            DropTable("dbo.Contas");
            DropTable("dbo.Accounts");
        }
    }
}
