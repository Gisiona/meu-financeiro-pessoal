using System.Configuration;

namespace OEconomicoPessoal.Utils.Configuracao
{
    public class EmailConfiguracao
    {
        public string EmailOrigem { get; private set; }
        public string EmailSenhaOrigem { get; private set; }
        public string EmailSmtp { get; private set; }
        public string EmailEncoding { get; private set; }
        public int EmailPorta { get; private set; }
        public bool EmailEnableSsl { get; private set; }

        public EmailConfiguracao()
        {
            this.EmailSmtp = ConfigurationManager.AppSettings["EmailSmtp"];
            this.EmailEncoding = ConfigurationManager.AppSettings["EmailEncoding"];
            this.EmailPorta = int.Parse(ConfigurationManager.AppSettings["EmailPorta"]);
            this.EmailEnableSsl = bool.Parse(ConfigurationManager.AppSettings["EmailEnableSsl"]);
            this.EmailOrigem = ConfigurationManager.AppSettings["EmailOrigem"];
            this.EmailSenhaOrigem = ConfigurationManager.AppSettings["EmailSenhaOrigem"];
        }
    }
}