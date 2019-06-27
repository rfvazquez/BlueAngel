using System;
using System.Net;
using System.Net.Mail;

namespace AnjoAzul.Util
{
    public static class EmailUtils
    {
        public static string SendMail(string titulo, string mensagem, string emailRecipiente)
        {
            var ret = "";
            try
            {
                var emailEnvio = "sistema.anjoazul@gmail.com";
                var senhaEmail = "2402C@mila";

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(emailEnvio);
                mail.To.Add(emailRecipiente); // para
                mail.Subject = titulo; // assunto
                mail.Body = mensagem; // mensagem
                mail.IsBodyHtml = true;


                using (var smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.EnableSsl = true; // GMail requer SSL
                    smtp.Port = 587;       // porta para SSL
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                    smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                    // seu usuário e senha para autenticação
                    smtp.Credentials = new NetworkCredential(emailEnvio, senhaEmail);

                    // envia o e-mail
                    smtp.Send(mail);
                }

                ret = "E-Mail enviado com sucesso!";
            }
            catch (Exception ex)
            {
                ret = $"Erro: {ex.Message}";
            }
            return ret;
        }

    }
}
