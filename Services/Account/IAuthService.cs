namespace Twitter_backend.Services.Account
{
    using System.Threading.Tasks;
    using Twitter_backend.Entities;
    using Twitter_backend.Models;

    public interface IAuthService
    {
        AuthorizeResponse Authorize(AuthorizeRequest model);

        Task<AuthorizeResponse> Registration(User user);

        User GetById(int id);
    }
}
