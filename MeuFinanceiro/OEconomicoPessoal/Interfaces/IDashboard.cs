using OEconomicoPessoal.Entidades;
using System.Collections.Generic;

namespace OEconomicoPessoal.Interfaces
{
    public interface IDashboard
    {
        List<Despesa> GetDespesas(int IdAccount);
        List<Conta> GetContas(int IdAccount);
        List<Receita> GetReceitas(int IdAccount);
        decimal TotalDespesasMes(int IdAccount);
        decimal TotalReceitasMes(int IdAccount);
        decimal TotalAcumuladoContas(int IdAccount);
    }
}
