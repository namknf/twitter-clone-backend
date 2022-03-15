namespace Twitter_backend.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Twitter_backend.Models;
    using Twitter_backend.Data;
    using System.Collections.Generic;

    public class AuthRegisterRepository<T> : IAuthRegisterRepository<T>
        where T : ModelBase
    {
        private readonly TwitterContext _dbContext;

        public AuthRegisterRepository(TwitterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public async Task<int> Add(T entity)
        {
            var addedItem = await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return addedItem.Entity.Id;
        }

        public T GetById(int id)
        {
            var gettingItem = _dbContext.Set<T>().FirstOrDefault(item => item.Id == id);

            return gettingItem;
        }
    }
}
