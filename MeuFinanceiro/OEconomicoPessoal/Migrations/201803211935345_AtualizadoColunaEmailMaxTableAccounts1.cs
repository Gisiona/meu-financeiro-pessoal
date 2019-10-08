namespace OEconomicoPessoal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadoColunaEmailMaxTableAccounts1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Email", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Accounts", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "Email" });
            AlterColumn("dbo.Accounts", "Email", c => c.String(nullable: false, maxLength: 4000));
        }
    }
}
