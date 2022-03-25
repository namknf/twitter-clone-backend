namespace Twitter_backend.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemsRepository<T>
    {
        T GetById(int id);

        List<T> GetAll();

        Task<int> Add(T entity);

        Task<int> Remove(T entity);

        Task<int> Update(T entity);
    }
}
