namespace Twitter_backend.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Entities;
    using Twitter_backend.Helpers;
    using Twitter_backend.Models;
    using BCryptNet = BCrypt.Net.BCrypt;

    public class UserService : IUserService
    {
        private readonly UsersContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _map;

        public UserService(UsersContext context, IConfiguration configuration, IMapper map)
        {
            _dbContext = context;
            _configuration = configuration;
            _map = map;
        }

        public AuthorizeResponse Authenticate(AuthorizeRequest model)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == model.Email);

            // verify password
            if (user == null || !BCryptNet.Verify(model.PasswordHash, user.PasswordHash))
            {
                throw new ApplicationException("Email or password is incorrect!");
            }

            // authentication success
            var response = _map.Map<AuthorizeResponse>(user);
            response.Token = _configuration.GenerateJwtToken(user);

            return new AuthorizeResponse(user, token);
        }

        public Task<AuthorizeResponse> Registration(UserModel userModel)
        {
            var user = _map.Map<User>(userModel);
            var addedUser = _dbContext.Add(user);

            var response = Authenticate(
                new AuthorizeRequest
                {
                    Email = user.Email,
                    PasswordHash = user.PasswordHash
                });
        }

        public UserModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
