using OEconomicoPessoal.Infra.DaoEF;
using OEconomicoPessoal.Interfaces;
using OEconomicoPessoal.Utils.Validation;
using System.Collections.Generic;

namespace OEconomicoPessoal.Repositorios
{
    public class DashboardRepositorio:IDashboard
    {
        private readonly DashboardValidation _validation;
        private readonly DashboardDao _dao;

        public DashboardRepositorio()
        {
            this._validation = new DashboardValidation();
            this._dao = new DashboardDao();
        }

        public List<Entidades.Despesa> GetDespesas(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.GetDespesas(IdAccount);
        }

        public List<Entidades.Conta> GetContas(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.GetContas(IdAccount);
        }

        public List<Entidades.Receita> GetReceitas(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.GetReceitas(IdAccount);
        }

        public decimal TotalDespesasMes(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.TotalDespesasMes(IdAccount);
        }

        public decimal TotalReceitasMes(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.TotalReceitasMes(IdAccount);
        }

        public decimal TotalAcumuladoContas(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.TotalAcumuladoContas(IdAccount);
        }
    }
}