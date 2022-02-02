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
        private readonly UserRepository<User> _userRepository;
        private readonly UsersContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _map;

        public UserService(UsersContext context, IConfiguration configuration, IMapper map, UserRepository<User> userRepository)
        {
            _dbContext = context;
            _configuration = configuration;
            _map = map;
            _userRepository = userRepository;
        }

        public AuthorizeResponse Authorize(AuthorizeRequest model)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == model.Email);

            // verify password
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                throw new ApplicationException("Email or password is incorrect!");
            }

            // authorize success
            var token = _configuration.GenerateJwtToken(user);

            return new AuthorizeResponse(user, token);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public Task<AuthorizeResponse> Registration(User userModel)
        {
            // map model to new user object
            var user = _map.Map<User>(userModel);

            // validate
            if (_dbContext.Users.Any(x => x.Email == userModel.Email))
            {
                throw new ApplicationException("Email " + user.Email + " is already exists");
            }

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
