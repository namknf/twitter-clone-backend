namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Twitter_backend.Models;

    [Route("/api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private UsersContext _db; // Get data context

        public UserController(UsersContext context)
        {
            _db = context;

            if (!_db.Users.Any())
            {
                _db.Users.Add(new User { Email = "nastya@mail.ru", Password = 1256327 });
                _db.Users.Add(new User { Email = "rombik@gmail.com", Password = 317382487 });
                _db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            User user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _db.Users.Add(user); // Create sql-expresiion INSERT

            // executes expression
            // Add data in database
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
