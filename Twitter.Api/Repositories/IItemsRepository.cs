namespace Twitter_backend.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal interface IItemsRepository<T>
    {
        T GetById(int id);

        List<T> GetAll();

        Task<int> Add(T entity);

        Task<int> Remove(T entity);
    }
}
