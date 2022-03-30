namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Contract;
    using Twitter_backend.Models.ForMappers;
    using Twitter_backend.Requests;
    using Twitter_backend.Responses;
    using Twitter_backend.Services.Account;

    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// authenticates the user and generates a token.
        /// </summary>
        /// <param name="request">.</param>
        /// <returns>action result.</returns>
        /// <response code="201">returns the authorized user.</response>
        /// <response code="400">if the user is null.</response>
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

        /// <summary>
        /// registers a user. After registration, the user becomes authorized.
        /// </summary>
        /// <param name="user">.</param>
        /// <returns>registered user.</returns>
        /// <response code="201">returns the registered user.</response>
        /// <response code="400">if the user is null or email is not confirmed.</response>
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
                new { code = response.Token },
                protocol: HttpContext.Request.Scheme);

            var emailService = new EmailService();

            await emailService.SendEmailAsync(
                "Confirm your account",
                $"Fine! You have become a member of our team. Welcome to Twitter! Confirm registration by clicking on the link: <a href='{callbackUrl}'>link</a>",
                response);

            return Content("To complete the registration, confirm your email and be sure to follow the link sent by mail");
        }

        /// <summary>
        /// exits the application.
        /// </summary>
        /// <param name="response">.</param>
        /// <returns>remove token.</returns>
        /// <response code="201">returns the user who has logged out of the application.</response>
        /// <response code="400">if the user is unauthorized.</response>
        [HttpPost(ApiRoutes.Accounts.LogOut)]
        public Task<IActionResult> LogOut(AuthorizeResponse response)
        {
            if (response.Token == null)
            {
                return Task.FromResult<IActionResult>(BadRequest(new { message = "You are not authorized" }));
            }

            response.Token = null;

            return Task.FromResult<IActionResult>(Ok());
        }

        /// <summary>
        /// email confirmation during registration and authorization.
        /// </summary>
        /// <param name="userid">user's id.</param>
        /// <param name="code">token.</param>
        /// <returns>verified mail or not.</returns>
        /// <response code="201">if email is confirmed.</response>
        /// <response code="400">if email is not confirmed.</response>
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
