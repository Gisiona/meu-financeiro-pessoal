using OEconomicoPessoal.Entidades;
using OEconomicoPessoal.Utils;
using OEconomicoPessoal.Utils.Configuracao;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace OEconomicoPessoal.Repositorios
{
    public class EmailRepositorio
    {
        private static EmailConfiguracao _emailConfig = new EmailConfiguracao();
        public EmailRepositorio()
        {
        }

        public string EnviarEmailContato(string snome, string semail, string smensagem)
        {
            string from = "transdoc.envio@gmail.com"; //example:- sourabh9303@gmail.com
            using (MailMessage mail = new MailMessage(from, "acslook@hotmail.com"))
            {
                mail.Subject = "Transdoc - Dúvida ou sugestão de cliente";
                mail.Body = "**** Informações da mensagem ****\n\n" +
                    "Nome: " + snome + "\n" +
                    "E-mail: " + semail + "\n" +
                    "Mensagem: " + smensagem + "\n\n\n";

                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, "entrega2015");
                //smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
                //ViewBag.Message = "Sent";
            }

            return "EnvioEmail";
        }

        public static string EnviarEmailCadastroNovoUsuario(Account account)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress("gilcosta.ti@gmail.com");
                //objEmail.ReplyTo = "";
                objEmail.To.Add(account.Email);
                //objEmail.Bcc.Add("Email oculto");
                objEmail.Priority = MailPriority.Normal;
                objEmail.IsBodyHtml = false;
                objEmail.Subject = "Meu Financeiro - Cadastro realizado com sucesso"; 
                objEmail.Body = "Estamos muito felizes por saber que você fez seu cadastro na plataforma Meu Financeiro. Qualquer problema ou sugestão por favor entre em contato conosco. \n\n" +
                        "Nome: " + account.Nome + "\n" +
                        "Telefone: " + account.Telefone + "\n" +
                        "E-mail: " + account.Email + "\n" +
                        "Senha: " + Criptografia.Descriptografar(account.Senha) + "\n" +
                        "Link de Acesso: " + "http://oeconomista.azurewebsites.net/" + "\n" +
                        "\n\n\n" +
                        "Atenciosamente: " + "\n" +
                        "Equipe Meu Financeiro" + "\n" +
                        "WhatsApp: (11) 9 7951-0575";
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = "smtp.gmail.com";
                objSmtp.EnableSsl = true;
                objSmtp.Port = 587;
                objSmtp.Credentials = new NetworkCredential(_emailConfig.EmailOrigem,_emailConfig.EmailSenhaOrigem);
                objSmtp.Send(objEmail);
            }
            catch 
            {
                return null;
            }
            return "Usuário criado com sucesso... Todos os dados foram enviados para seu e-mail: " + account.Email;           
        }
        
        //envio de e-mail para o cliente
        public static bool EnviarEmailCliente(string cnome, string ctelefone, string cemail, string ccotacao, string cmessage)
        {
            string from = "transdoc.envio@gmail.com"; //example:- sourabh9303@gmail.com
            try
            {
                using (MailMessage mail = new MailMessage(from, cemail))
                {
                    mail.Subject = "Transdoc - Cotação online";
                    mail.Body = "**** Obrigado por utilizar nosso serviço. Em instantes entraremos em contato ****\n\n" +
                        "Nome do cliente: " + cnome + "\n" +
                        "Telefone: " + ctelefone + "\n" +
                        "E-mail: " + cemail + "\n" +
                        "Mensagem: " + cmessage + "\n\n\n" +
                        "<br/><br/> " +

                        "**** Ddos da sua cotação ****\n\n" +
                        ccotacao;

                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "entrega2015");
                    //smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                   // ViewBag.Message = "Sent";
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um falha no envio do e-mail. Tente novamente.   " + ex.Message);
                return false;
            }
        }
        
        public string EnviarEmail(string to, string from, string smensagem)
        {
            throw new NotImplementedException();
        }

        public static void Enviaremail(string paraqualemail, string assunto, string mensagem)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress("gilcosta.ti@gmail.com");
                //objEmail.ReplyTo = "";
                objEmail.To.Add(paraqualemail);
                //objEmail.Bcc.Add("Email oculto");
                objEmail.Priority = MailPriority.Normal;
                objEmail.IsBodyHtml = true;
                objEmail.Subject = assunto;
                objEmail.Body = mensagem;
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = "smtp.gmail.com";
                objSmtp.EnableSsl = true;
                objSmtp.Port = 587;
                objSmtp.Credentials = new NetworkCredential("gilcosta.ti@gmail.com", "13579aabbc");
                objSmtp.Send(objEmail);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            
        }
        
        public static string EnviarEmailRecuperacaoSenha(Account account)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress(_emailConfig.EmailOrigem);
                //objEmail.ReplyTo = "";
                objEmail.To.Add(account.Email);
                objEmail.Bcc.Add("gil-real@hotmail.com");
                objEmail.Priority = MailPriority.Normal;
                objEmail.IsBodyHtml = false;
                objEmail.Subject = "Meu Financeiro - Recuperação de senha"; 
                objEmail.Body = "Estamos muito felizes por saber que estar de volta a plataforma Meu Financeiro. Segue abaixo os dados de acesso a plataforma. \n\n" +
                        "Nome: " + account.Nome + "\n" +
                        "Telefone: " + account.Telefone + "\n" +
                        "E-mail: " + account.Email + "\n" +
                        "Senha: " + Criptografia.Descriptografar(account.Senha) + "\n" +
                        "Link de Acesso: " + "http://oeconomista.azurewebsites.net/account/criarnovasenha?email=" + account.Email + "&hashcode="+ account.Senha + "\n" +
                        "\n\n\n" +
                        "Atenciosamente: " + "\n" +
                        "Equipe Meu Financeiro" + "\n" +
                        "WhatsApp: (11) 9 7951-0575";
                objEmail.SubjectEncoding = Encoding.GetEncoding(_emailConfig.EmailEncoding);
                objEmail.BodyEncoding = Encoding.GetEncoding(_emailConfig.EmailEncoding);
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = _emailConfig.EmailSmtp;
                objSmtp.EnableSsl = _emailConfig.EmailEnableSsl;
                objSmtp.Port = _emailConfig.EmailPorta;
                objSmtp.Credentials = new NetworkCredential(_emailConfig.EmailOrigem, _emailConfig.EmailSenhaOrigem);
                objSmtp.Send(objEmail);

                //Habilitar o envio de e-mail do gmail
                //https://myaccount.google.com/lesssecureapps
            }
            catch 
            {
                throw new Exception("Este recurso está temporariamente indisponível. Tem novamente mais tarde.");
            }
            return "Os dados de acesso foram enviados para o e-mail informado.";           
        }

    }
}