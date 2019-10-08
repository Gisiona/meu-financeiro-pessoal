using OEconomicoPessoal.Dao;
using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OEconomicoPessoal.Infra.DaoEF
{
    public class DespesaDao: IDespesa
    {
        private readonly OEconomicoContext _context;

        public DespesaDao()
        {
            this._context = new OEconomicoContext();
        }
        public void Salvar(Despesa entity)
        {
            try
            {
                _context.Despesas.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao criar despesa.");
            }
        }

        public void Atualizar(Despesa entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao atualizar despesa.");
            }
        }

        public void Excluir(Despesa entity)
        {
            try
            {
                _context.Despesas.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao remover despesa.");
            }
        }

        public Despesa ConsultarPorId(int id)
        {
            try
            {
                return _context.Despesas.Find(id);
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar despesa.");
            }
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public List<Despesa> ListarTodasDespesasPorUsuario(int IdAccount)
        {
            try
            {
                var despesas = from c in _context.Despesas.Where(p => p.AccountId == IdAccount)
                               select c;
                return despesas.ToList<Despesa>();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar despesa do usuário.");
            }
        }


        public void SalvarTipoDespesa(TipoDespesa tipoDespesa)
        {
            try
            {
                _context.TipoDespesas.Add(tipoDespesa);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao criar uma nova tipo de despesa.");
            }
        }

        public List<TipoDespesa> ListarTipoDespesasPorUsuario(int p)
        {
            try
            {
                var tipo = from c in _context.TipoDespesas.Where(t => t.AccountId == p)
                               select c;
                return tipo.ToList<TipoDespesa>();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao listar os tipo de despesa do usuário.");
            }
        }

        internal List<TipoPagamento> ListarFormaPagamentoPorUsuario(int p)
        {
            try
            {
                var tipo = from c in _context.TipoPagamentos.Where(t => t.AccountId == p)
                           select c;
                return tipo.ToList<TipoPagamento>();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao listar os tipo de pagamento do usuário.");
            }
        }
    }
}