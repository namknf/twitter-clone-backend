namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Contract;
    using Twitter_backend.Models.ForMappers;
    using Twitter_backend.Requests;
    using Twitter_backend.Responses;
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

            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code = response.Token },
                protocol: HttpContext.Request.Scheme);

            var emailService = new EmailService();

            await emailService.SendEmailAsync(
                "Confirm your account",
                $"Fine! You have become a member of our team. Welcome to Twitter! Confirm registration by clicking on the link: <a href='{callbackUrl}'>link</a>",
                response);

            return Content("To complete the registration, confirm your email and be sure to follow the link sent by mail");
        }

        [HttpPost(ApiRoutes.Accounts.LogOut)]
        public async Task<IActionResult> LogOut(AuthorizeResponse response)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(ApiRoutes.Accounts.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail(int userid, string code)
        {
            if (code == null)
            {
                return BadRequest(new { message="Something went wrong..." });
            }

            var user = _authService.GetById(userid);

            if (user == null)
            {
                return BadRequest(new { message= "No such user exists" });
            }

            var result = await _authService.ConfirmEmail(userid, code);

            if (result)
            {
                return Ok();
            }

            return BadRequest(new { message= "User is not registered" });
        }
    }
}
