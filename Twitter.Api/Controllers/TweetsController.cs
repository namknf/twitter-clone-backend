namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Models;

    [Route("api/users/{user-id}/tweets")]
    [ApiController]
    public class TweetsController : Controller
    {
    }
}
