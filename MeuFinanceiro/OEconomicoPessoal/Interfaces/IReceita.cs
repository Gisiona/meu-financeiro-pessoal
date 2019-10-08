using OEconomicoPessoal.Entidades;
using System.Collections.Generic;

namespace OEconomicoPessoal.Interfaces
{
    public interface IReceita : IBase<Receita>
    {
           void SalvarTipoReceita(TipoReceita tipoReceita);
           List<Receita> ListarTodasReceitasPorUsuario(int IdAccount);

    }
}
