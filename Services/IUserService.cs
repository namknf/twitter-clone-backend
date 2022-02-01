namespace Twitter_backend.Services
{
    using System.Threading.Tasks;
    using Twitter_backend.Entities;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        Task<AuthenticateResponse> Registration(UserModel userModel);

        UserModel GetById(int id);
    }
}
