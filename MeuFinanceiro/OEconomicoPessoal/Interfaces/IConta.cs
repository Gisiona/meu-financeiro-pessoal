using OEconomicoPessoal.Entidades;
using System.Collections.Generic;

namespace OEconomicoPessoal.Interfaces
{
    public interface IConta: IBase<Conta>
    {
        List<Conta> ListarTodasContasPorUsuario(int IdAccount);
    }
}
