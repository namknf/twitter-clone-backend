namespace Twitter_backend.Services.Account
{
    using System.Threading.Tasks;
    using Twitter_backend.Models;
    using Twitter_backend.Requests;
    using Twitter_backend.Responses;

    public interface IAuthService
    {
        AuthorizeResponse Authorize(AuthorizeRequest model);

        Task<AuthorizeResponse> Registration(User user);

        User GetById(int id);
    }
}
