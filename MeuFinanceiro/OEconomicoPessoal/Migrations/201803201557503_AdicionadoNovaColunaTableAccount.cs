namespace OEconomicoPessoal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoNovaColunaTableAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "ConfirmarSenha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "ConfirmarSenha");
        }
    }
}
