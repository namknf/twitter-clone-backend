namespace Twitter_backend.Repositories
{
    using System.Threading.Tasks;
    using Twitter_backend.Models;

    internal interface IAuthRegisterRepository<T>
        where T : ModelBase
    {
        T GetById(int id);

        Task<int> Add(T entity);
    }
}
