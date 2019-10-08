namespace OEconomicoPessoal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnTableAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "DataAtualizacao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "DataAtualizacao");
        }
    }
}
