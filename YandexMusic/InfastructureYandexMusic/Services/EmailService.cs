using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InfastructureYandexMusic.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // настройка логина, пароля отправителя
            var from = "yandexmusic2020@mail.ru";
            var pass = "utb}ty4PIII3";

            // адрес и порт smtp(SimpleMailTransferPort)-сервера, с которого мы и будем отправлять письмо
            SmtpClient client = new SmtpClient("smtp.mail.ru", 587);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pass);
            client.EnableSsl = true;

            // создаем письмо: message.Destination - адрес получателя
            var mail = new MailMessage(from, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true,
            };

            return client.SendMailAsync(mail);
        }
    }
}
