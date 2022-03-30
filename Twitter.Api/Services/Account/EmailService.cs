namespace Twitter_backend.Services.Account
{
    using System.Threading.Tasks;
    using MailKit.Net.Smtp;
    using MimeKit;
    using Twitter_backend.Responses;

    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string subject, string message, AuthorizeResponse user)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress("Application's admin", "anastmalkina0@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress("user", user.Email));
            mimeMessage.Subject = subject;

            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message,
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 465, true);
            await client.AuthenticateAsync(user.Email, user.Password);
            await client.SendAsync(mimeMessage);

            await client.DisconnectAsync(true);
        }
    }
}
