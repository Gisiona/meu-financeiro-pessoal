using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Infra.DaoEF;
using OEconomicoPessoal.Interfaces;
using OEconomicoPessoal.Utils.Validation;
using System;
using System.Collections.Generic;

namespace OEconomicoPessoal.Repositorios
{
    public class ReceitaRepositorio: IReceita
    {
        private readonly ReceitaValidation _validation;
        private readonly ReceitaDao _dao;

        public ReceitaRepositorio()
        {
            this._validation = new ReceitaValidation();
            this._dao = new ReceitaDao();
        }
        public void Salvar(Entidades.Receita entity)
        {
            _validation.ValidarReceitaIsValido(entity);
            _dao.Salvar(entity);
        }

        public void Atualizar(Entidades.Receita entity)
        {
            _validation.ValidarReceitaIsValido(entity);
            _dao.Atualizar(entity);
        }

        public void Excluir(Entidades.Receita entity)
        {
            _validation.IsNullOrEmpty(entity.Id);
            _dao.Excluir(entity);
        }

        public Entidades.Receita ConsultarPorId(int id)
        {
            _validation.IsNullOrEmpty(id);
            return _dao.ConsultarPorId(id);
        }

        public void SaveChanges()
        {
            throw new Exception("OPS... Este método não possui implementação.");
        }

        public void SalvarTipoReceita(Entidades.TipoReceita tipoReceita)
        {
            _validation.IsNullOrEmpty(tipoReceita.Descricao);
            _dao.SalvarTipoReceita(tipoReceita);
        }

        public List<Entidades.Receita> ListarTodasReceitasPorUsuario(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.ListarTodasReceitasPorUsuario(IdAccount);
        }

        public List<TipoReceita> ListarTipoReceitaPorUsuario(int p)
        {
            _validation.IsNullOrEmpty(p);
            return _dao.ListarTipoReceitaPorUsuario(p);
        }
    }
}