namespace Twitter_backend.Services.Account
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Entities;
    using Twitter_backend.Models;
    using Twitter_backend.Repositories;
    using Twitter_backend.Data;
    using Twitter_backend.Helpers;
    using BCryptNet = BCrypt.Net.BCrypt;

    public class AuthService : IAuthService
    {
        private readonly AuthRegisterRepository<User> _authRepository;
        private readonly TwitterContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _map;

        public AuthService(IConfiguration configuration, IMapper map, AuthRegisterRepository<User> authRepository, TwitterContext context)
        {
            _configuration = configuration;
            _map = map;
            _authRepository = authRepository;
            _context = context;
        }

        public AuthorizeResponse Authorize(AuthorizeRequest model)
        {
            var user = _authRepository.GetAll().FirstOrDefault(item => item.Email == model.Email);

            if (user != null)
            {
                user.Password = model.Password;

                var isValid = BCryptNet.Verify(model.Password, user.PasswordHash);

                if (isValid)
                {
                    var token = _configuration.GenerateJwtToken(user);

                    return new AuthorizeResponse(user, token);
                }
            }

            return null;
        }

        public User GetById(int id)
        {
            return _authRepository.GetById(id);
        }

        public async Task<AuthorizeResponse> Registration(User userModel)
        {
            // map model to new user object
            var user = _map.Map<User>(userModel);

            if (_context.Users.Any(us => us.Email == userModel.Email))
            {
                throw new ArgumentException("This email already exists");
            }

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(user.Password);

            await _authRepository.Add(userModel);

            var response = Authorize(
                new AuthorizeRequest
                {
                    Email = user.Email,
                    Password = user.PasswordHash,
                });

            return response;
        }
    }
}
