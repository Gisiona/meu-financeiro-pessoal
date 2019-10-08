using OEconomicoPessoal.Entidades;

namespace OEconomicoPessoal.Interfaces
{
    interface IAccount: IBase<Account>
    {
        Account ConsultarUsuarioPorEmailSenha(Account entity);
        Account AutenticarUsuario(string email, string senha);
        Account RecuperaUsuarioPorID(int IdAccount);
        Account RecuperaUsuarioPorEmail(string email);
        void CriarNovaSenha(string email, string hashcode, string senha, string confirmeSenha);
        //Account RecuperarSenha(string email);
    }
}
