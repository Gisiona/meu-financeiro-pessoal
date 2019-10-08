using OEconomicoPessoal.Dao;
using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OEconomicoPessoal.Infra.DaoEF
{
    public class ReceitaDao:IReceita
    {
        private readonly OEconomicoContext _context;
        public ReceitaDao()
        {
            this._context = new OEconomicoContext();
        }

        public void Salvar(Entidades.Receita entity)
        {
            try
            {
                _context.Receitas.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao adicionar receita.");
            }
        }

        public void Atualizar(Entidades.Receita entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao atualizar receita.");
            }
        }

        public void Excluir(Entidades.Receita entity)
        {
            try
            {
                _context.Receitas.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao remover receita.");
            }
        }

        public Entidades.Receita ConsultarPorId(int id)
        {
            try
            {
                return _context.Receitas.Find(id);
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar receita.");
            }
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public List<Receita> ListarTodasReceitasPorUsuario(int IdAccount)
        {
            try
            {
                var receitas = from c in _context.Receitas.Where(p => p.AccountId == IdAccount)
                               select c;
                return receitas.ToList<Receita>();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao consultar receita do usuário.");
            }
        }


        public void SalvarTipoReceita(TipoReceita tipoReceita)
        {
            try
            {
                _context.TipoReceitas.Add(tipoReceita);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao criar um novo tipo de receita.");
            }
        }

        public List<TipoReceita> ListarTipoReceitaPorUsuario(int p)
        {
            try
            {
                var tipo = from c in _context.TipoReceitas.Where(t => t.AccountId == p)
                           select c;
                return tipo.ToList<TipoReceita>();
            }
            catch (Exception)
            {
                throw new Exception("OPS... Erro ao listar os tipo de receita do usuário.");
            }
        }
    }
}