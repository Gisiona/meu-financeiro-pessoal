
namespace OEconomicoPessoal.Interfaces
{
    public interface IEmail
    {
        string EnviarEmailContato(string snome, string semail, string smensagem);
        string EnviarEmailCadastroNovoUsuario(string cnome, string ctelefone, string cemail, string ccotacao, string cmessage);
        bool EnviarEmailCliente(string cnome, string ctelefone, string cemail, string ccotacao, string cmessage);
        string EnviarEmail(string to, string from, string smensagem);

    }
}