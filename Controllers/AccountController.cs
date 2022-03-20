namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Models;
    using Twitter_backend.Requests;
    using Twitter_backend.Services.Account;

    [Route("/api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthorizeRequest request)
        {
            var response = _authService.Authorize(request);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password are incorrect" });
            }

            return Ok();
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register(User user)
        {
            var response = await _authService.Registration(user);

            if (response == null)
            {
                return BadRequest(new { message = "User didn't register" });
            }

            return Ok(response);
        }
    }
}
