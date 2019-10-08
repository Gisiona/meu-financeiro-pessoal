using OEconomicoPessoal.Infra.DaoEF;
using OEconomicoPessoal.Interfaces;
using OEconomicoPessoal.Utils.Validation;
using System;
using System.Collections.Generic;

namespace OEconomicoPessoal.Repositorios
{
    public class ContaRepositorio: IConta
    {
        private readonly ContaDao _dao;
        private readonly ContaValidation _validation;
             
        public ContaRepositorio()
        {            
            this._dao = new ContaDao();
            this._validation = new ContaValidation();
        }

        public void Salvar(Entidades.Conta entity)
        {
            _validation.IsNullOrEmpty(entity.Descricao);
            _dao.Salvar(entity);
        }

        public void Atualizar(Entidades.Conta entity)
        {
            _validation.IsNullOrEmpty(entity.Id.ToString(), entity.Descricao);
            _dao.Atualizar(entity);
        }

        public void Excluir(Entidades.Conta entity)
        {
            _validation.IsNullOrEmpty(entity.Id);
            _dao.Excluir(entity);
        }

        public Entidades.Conta ConsultarPorId(int id)
        {
            _validation.IsNullOrEmpty(id);
            return _dao.ConsultarPorId(id);
        }

        public void SaveChanges()
        {
            throw new Exception("OPS... Este método não possui implementação.");
        }

        public List<Entidades.Conta> ListarTodasContasPorUsuario(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.ListarTodasContasPorUsuario(IdAccount);
        }
    }
}