using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Infra.Maps;

namespace OEconomicoPessoal.Dao
{
    public class OEconomicoContext:DbContext
    {
        //public MeuFinanceiroPessoalContext()
        //    : base("DemoMigrationsConn")
        //{}

        public OEconomicoContext()
            : base(@"Data Source = SQL7003.site4now.net; Initial Catalog = DB_A2FAC6_gisiona; User Id = DB_A2FAC6_gisiona_admin; Password =13579aabbc")
            //: base(@"Data Source=WIN-68GCQG5NS0\SQLEXPRESS;Initial Catalog=OEconomico;Integrated Security=True")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // remove as configuracoes default de pluralizacao do entityFramework
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // modelBuilder.ComplexType<Account>();

            base.OnModelCreating(modelBuilder);

            // mapeamento e configuraçao da tabelas
            modelBuilder.Configurations.Add(new ContaMap());
            modelBuilder.Configurations.Add(new TipoReceitaMap());
            modelBuilder.Configurations.Add(new TipoDespesaMap());
            modelBuilder.Configurations.Add(new TipoPagamentoMap());
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new ReceitaMap());
            modelBuilder.Configurations.Add(new DespesaMap());

        }

        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<TipoDespesa> TipoDespesas { get; set; }
        public DbSet<TipoReceita> TipoReceitas { get; set; }
        public DbSet<TipoPagamento> TipoPagamentos { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Account> Accounts { get; set; } 
    }
}