namespace Twitter_backend.Services.Account
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Data;
    using Twitter_backend.Helpers;
    using Twitter_backend.Models;
    using Twitter_backend.Models.ForMappers;
    using Twitter_backend.Repositories;
    using Twitter_backend.Requests;
    using Twitter_backend.Responses;
    using BCryptNet = BCrypt.Net.BCrypt;

    internal class AuthService : IAuthService
    {
        private readonly IAuthRegisterRepository<User> _authRepository;
        private readonly TwitterContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _map;

        public AuthService(
            IConfiguration configuration,
            IMapper map,
            IAuthRegisterRepository<User> authRepository,
            TwitterContext context)
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

        public async Task<AuthorizeResponse> Registration(RegisterModel userModel)
        {
            // map model to new user object
            var user = _map.Map<User>(userModel);

            if (_context.Users.Any(us => us.Email == userModel.Email))
            {
                throw new ArgumentException("This email already exists");
            }

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(userModel.Password);

            await _authRepository.Add(user);

            var response = Authorize(
                new AuthorizeRequest
                {
                    Email = user.Email,
                    Password = user.Password,
                });

            return response;
        }
    }
}
