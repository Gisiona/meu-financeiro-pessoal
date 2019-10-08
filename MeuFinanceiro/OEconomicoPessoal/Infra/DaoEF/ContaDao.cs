using OEconomicoPessoal.Dao;
using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OEconomicoPessoal.Infra.DaoEF
{
    public class ContaDao: IConta
    {
        private readonly OEconomicoContext _context;

        public ContaDao()
        {
            this._context = new OEconomicoContext();
        }

        public void Salvar(Entidades.Conta entity)
        {
            try
            {
                _context.Contas.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao criar conta.");
            }
        }

        public void Atualizar(Entidades.Conta entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao atualizar conta.");
            }
        }

        public void Excluir(Entidades.Conta entity)
        {
            try
            {
                _context.Contas.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao remover conta.");
            }
        }

        public Entidades.Conta ConsultarPorId(int id)
        {
            try
            {
                return _context.Contas.Find(id);
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar contas.");
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Conta> ListarTodasContasPorUsuario(int IdAccount)
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
    }
}