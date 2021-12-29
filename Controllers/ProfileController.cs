namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Twitter_backend.Models;

    [ApiController]
    public class ProfileController : Controller
    {
        private ProfilesContext _db;

        public ProfileController(ProfilesContext context)
        {
            _db = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Profile>>> Get(int id)
        {
            Profile profile = await _db.Profiles.FirstOrDefaultAsync(x => x.Id == id);

            if (profile == null)
            {
                return NotFound();
            }

            return new ObjectResult(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profile profile)
        {
            _db.Profiles.Add(profile);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
