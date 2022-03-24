namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Contract;
    using Twitter_backend.Models.ForMappers;
    using Twitter_backend.Requests;
    using Twitter_backend.Services.Account;

    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(ApiRoutes.Accounts.Authenticate)]
        public IActionResult Authenticate(AuthorizeRequest request)
        {
            var response = _authService.Authorize(request);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password are incorrect" });
            }

            return Ok();
        }

        [HttpPost(ApiRoutes.Accounts.Register)]
        public async Task<IActionResult> Register(RegisterModel user)
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
