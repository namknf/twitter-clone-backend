namespace Twitter_backend.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Twitter_backend.Data;
    using Twitter_backend.Models;

    public class ItemsRepository<T> : IItemsRepository<T>
        where T : ModelBase
    {
        private readonly TwitterContext _dbContext;

        public ItemsRepository(TwitterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(T entity)
        {
            var addedItem = _dbContext.Set<T>().Add(entity);

            await _dbContext.SaveChangesAsync();

            return addedItem.Entity.Id;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var needItem = _dbContext.Set<T>().FirstOrDefault(item => item.Id == id);

            return needItem;
        }

        public async Task<int> Remove(T entity)
        {
            var removedItem = _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();

            return removedItem.Entity.Id;
        }

        public async Task<int> Update(T entity)
        {
            var removedItem = _dbContext.Set<T>().Update(entity);

            await _dbContext.SaveChangesAsync();

            return removedItem.Entity.Id;
        }
    }
}
