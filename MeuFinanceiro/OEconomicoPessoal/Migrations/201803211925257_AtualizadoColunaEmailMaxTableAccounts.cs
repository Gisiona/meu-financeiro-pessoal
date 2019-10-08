namespace OEconomicoPessoal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadoColunaEmailMaxTableAccounts : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Accounts", new[] { "Email" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Accounts", "Email", unique: true);
        }
    }
}
