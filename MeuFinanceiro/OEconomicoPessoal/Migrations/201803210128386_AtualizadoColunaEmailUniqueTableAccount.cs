namespace OEconomicoPessoal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadoColunaEmailUniqueTableAccount : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "Email" });
        }
    }
}
