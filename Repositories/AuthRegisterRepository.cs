namespace Twitter_backend.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Twitter_backend.Models;

    public class AuthRegisterRepository<T> : IAuthRegisterRepository<T>
        where T : ModelBase
    {
        public Task<int> Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
