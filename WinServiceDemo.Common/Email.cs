using System.Net;
using System.Net.Mail;
using WinServiceDemo.Common.CustomExceptions;

namespace WinServiceDemo.Common
{
    public static class Email
    {
        public static void SendEmail(string subject,
            string body,
            string to)
        {
            var fromAddress = new MailAddress("some@email.com", "EmailDisplayName");
            var toAddress = new MailAddress(to);
            const string fromPassword = "pw";

            var smtp = new SmtpClient
            {
                Host = "host",
                Port = 111,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            var message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.Bcc.Add("some@email.com");
            message.Bcc.Add("some@email.com");
            try
            {
                smtp.Send(message);
            }
            catch (EmailException ex)
            {
                //TODO
                //Log to file

                throw new EmailException(ex.Message + "Additional Message");
            }
            finally
            {
                message.Dispose();
                smtp.Dispose();
            }
        }
    }
}
