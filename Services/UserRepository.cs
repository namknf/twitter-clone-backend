namespace Twitter_backend.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Twitter_backend.Models;

    public class UserRepository<T> : IAuthRegisterRepository<T>
        where T : ModelBase
    {
        private readonly UsersContext _context;

        public UserRepository(UsersContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public T GetById(int id)
        {
            var gettingId = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            if (gettingId == null)
            {
                return null;
            }

            return gettingId;
        }
    }
}
