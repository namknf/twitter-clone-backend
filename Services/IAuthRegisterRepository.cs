using System.Threading.Tasks;

namespace Twitter_backend.Services
{
    using Twitter_backend.Models;

    interface IAuthRegisterRepository<T> where T: ModelBase
    {
        T GetById(int id);
        Task<int> Add(T entity);
    }
}
