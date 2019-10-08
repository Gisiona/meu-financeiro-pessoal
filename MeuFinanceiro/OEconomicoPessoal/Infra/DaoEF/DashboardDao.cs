using OEconomicoPessoal.Dao;
using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OEconomicoPessoal.Infra.DaoEF
{
    public class DashboardDao : IDashboard
    {
        private readonly OEconomicoContext _context;

        public DashboardDao()
        {
            this._context = new OEconomicoContext();
        }

        public List<Entidades.Despesa> GetDespesas(int IdAccount)
        {
            try
            {
                var despesas = from c in _context.Despesas.Where(p => p.AccountId == IdAccount)
                               select c;
                return despesas.ToList<Despesa>();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar despesas do usuário.");
            }
        }

        public List<Entidades.Conta> GetContas(int IdAccount)
        {
            try
            {
                var contas = from c in _context.Contas.Where(p => p.AccountId == IdAccount)
                             select c;
                return contas.ToList<Conta>();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar contas do usuário.");
            }
        }

        public List<Entidades.Receita> GetReceitas(int IdAccount)
        {
            try
            {
                var receitas = from c in _context.Receitas.Where(p => p.AccountId == IdAccount)
                               select c;
                return receitas.ToList<Receita>();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar reeitas do usuário.");
            }
        }

        public decimal TotalDespesasMes(int IdAccount)
        {
            decimal valorTotalDespesa = 0;
            IQueryable<decimal> despesas =
                 from s in _context.Despesas
                 where s.AccountId >= IdAccount
                 select s.Valor;

            foreach (var item in despesas)
            {
                valorTotalDespesa += item;
            }
            return valorTotalDespesa;
        }

        public decimal TotalReceitasMes(int IdAccount)
        {
            decimal valorTotalReceita = 0;
            IQueryable<decimal> receitas =
                 from s in _context.Receitas
                 where s.AccountId >= IdAccount
                 select s.Valor;

            foreach (var item in receitas)
            {
                valorTotalReceita += item;
            }
            return valorTotalReceita;
        }

        public decimal TotalAcumuladoContas(int IdAccount)
        {
            return TotalReceitasMes(IdAccount) - TotalDespesasMes(IdAccount);
        }
    }
}