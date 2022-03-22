namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Models;

    [Route("api/users/{user-id}/tweets/{tweet-id}/comments")]
    [ApiController]
    public class CommentsController : Controller
    {
    }
}
