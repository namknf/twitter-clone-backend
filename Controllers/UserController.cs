namespace Twitter_backend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UsersContext _db; // Get data context

        public UserController(UsersContext context)
        {
            _db = context;
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
