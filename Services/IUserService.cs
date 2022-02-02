namespace Twitter_backend.Services
{
    using System.Threading.Tasks;
    using Twitter_backend.Entities;
    using Twitter_backend.Models;

    public interface IUserService
    {
        AuthorizeResponse Authorize(AuthorizeRequest model);

        Task<AuthorizeResponse> Registration(User user);

        User GetById(int id);
    }
}
