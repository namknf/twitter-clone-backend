namespace Twitter_backend.Services
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
