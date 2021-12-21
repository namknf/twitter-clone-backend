namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Models;

    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : Controller
    {
        private ProfilesContext _db;

        public ProfileController(ProfilesContext context)
        {
            _db = context;
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
