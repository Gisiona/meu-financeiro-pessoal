using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Enums;
using OEconomicoPessoal.Infra.DaoEF;
using OEconomicoPessoal.Interfaces;
using OEconomicoPessoal.Utils.Validation;
using System;
using System.Collections.Generic;

namespace OEconomicoPessoal.Repositorios
{
    public class DespesaRepositorio: IDespesa
    {
        private readonly DespesaValidation _validation;
        private readonly DespesaDao _dao;

        public DespesaRepositorio()
        {
            this._dao = new DespesaDao();
            this._validation = new DespesaValidation();
        }


        public void Salvar(Despesa entity)
        {
            _validation.ValidarDespesaIsValido(entity);
            _dao.Salvar(entity);
        }

        public void Atualizar(Despesa entity)
        {
            _validation.ValidarDespesaIsValido(entity, EAcaoFuncionalidade.Atualizar);
            _dao.Atualizar(entity);
        }

        public void Excluir(Despesa entity)
        {
            _dao.Excluir(entity);
        }

        public Despesa ConsultarPorId(int id)
        {
            return _dao.ConsultarPorId(id);
        }               

        public List<Despesa> ListarTodasDespesasPorUsuario(int IdAccount)
        {
            _validation.IsNullOrEmpty(IdAccount);
            return _dao.ListarTodasDespesasPorUsuario(IdAccount);
        }

        public void SaveChanges()
        {
            throw new Exception("OPS... Este método não possui implementação.");
        }


        public void SalvarTipoDespesa(TipoDespesa tipoDespesa)
        {
            _validation.IsNullOrEmpty(tipoDespesa.Descricao);
            _dao.SalvarTipoDespesa(tipoDespesa);
        }

        public List<TipoDespesa> ListarTipoDespesasPorUsuario(int p)
        {
            _validation.IsValorMenorQueZero(p);
            return _dao.ListarTipoDespesasPorUsuario(p);
        }

        public List<TipoPagamento> ListarFormaPagamentoPorUsuario(int p)
        {
            _validation.IsValorMenorQueZero(p);
            return _dao.ListarFormaPagamentoPorUsuario(p);
        }

    }
}