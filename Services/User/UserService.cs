namespace Twitter_backend.Services.User
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Entities;
    using Twitter_backend.Models;
    using Twitter_backend.Repositories;
    using BCryptNet = BCrypt.Net.BCrypt;

    public class UserService : IUserService
    {
        private readonly AuthRegisterRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _map;

        public UserService(IConfiguration configuration, IMapper map, AuthRegisterRepository<User> userRepository)
        {
            _configuration = configuration;
            _map = map;
            _userRepository = userRepository;
        }

        public AuthorizeResponse Authorize(AuthorizeRequest model)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public Task<AuthorizeResponse> Registration(User userModel)
        {
            // map model to new user object
            var user = _map.Map<User>(userModel);

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(user.Password);

            var response = Authorize(
                new AuthorizeRequest
                {
                    Email = user.Email,
                    Password = user.PasswordHash,
                });

            return Task.FromResult(response);
        }
    }
}
