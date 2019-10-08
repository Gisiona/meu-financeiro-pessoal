namespace OEconomicoPessoal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadoColunaMapTableAccount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "ConfirmarSenha", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "ConfirmarSenha", c => c.String(nullable: false));
        }
    }
}
