namespace Twitter_backend.Services
{
    using System.Threading.Tasks;
    using Twitter_backend.Entities;

    public interface IUserService
    {
        AuthorizeResponse Authenticate(AuthorizeRequest model);

        Task<AuthorizeResponse> Registration(UserModel userModel);

        UserModel GetById(int id);
    }
}
