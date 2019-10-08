
namespace OEconomicoPessoal.Interfaces
{
    public interface IBase<T> where T : class
    {
        void Salvar(T entity);
        void Atualizar(T entity);
        void Excluir(T entity);
        T ConsultarPorId(int id);
        void SaveChanges();
    }
}
