namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Twitter_backend.Models;

    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersContext _db; // Get data context

        public UsersController(UsersContext context)
        {
            _db = context;
        }

        // GET ../users/user-id
        [HttpGet("{user-id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // [HttpPost]
        // public async Task<IActionResult> Create(User user)
        // {
        //    _db.Users.Add(user); // Create sql-expression INSERT

        // // executes expression
        //    // Add data in database
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        // }
    }
}
