using OEconomicoPessoal.Entidades;
using System.Collections.Generic;

namespace OEconomicoPessoal.Models.ViewModel
{
    public class DashboardViewModel
    {
        public List<Despesa> GetDespesas { get; set; }
        public List<Conta> GetContas { get; set; }
        public List<Receita> GetReceitas { get; set; }
        public decimal TotalDespesasMes { get; set; }
        public decimal TotalReceitasMes { get; set; }
        public decimal TotalAcumuladoContas { get; set; }
    }
}