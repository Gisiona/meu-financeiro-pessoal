using OEconomicoPessoal.Entidades;
using System.Collections.Generic;

namespace OEconomicoPessoal.Interfaces
{
    public interface IDespesa: IBase<Despesa>
    {
       List<Despesa> ListarTodasDespesasPorUsuario(int IdAccount);
        void SalvarTipoDespesa(TipoDespesa tipoDespesa);
    }
}
