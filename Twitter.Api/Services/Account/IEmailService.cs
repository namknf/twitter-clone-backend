namespace Twitter_backend.Services.Account
{
    using System.Threading.Tasks;
    using Twitter_backend.Responses;

    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string message, AuthorizeResponse user);
    }
}
