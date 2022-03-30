namespace Twitter.Tests.RepositoriesTests
{
    using NUnit.Framework;
    using Twitter_backend.Data;
    using Twitter_backend.Models;
    using Twitter_backend.Repositories;

    [TestFixture]
    public class AuthRepoTests
    {
        private readonly AuthRegisterRepository<User> _authRepo;

        public AuthRepoTests()
        {
            var context = new TwitterContext();
            _authRepo = new AuthRegisterRepository<User>(context);
        }

        [Test]
        public void CanGetUser()
        {
            var id = 0;

            var user = _authRepo.GetById(id);

            Assert.AreEqual(id, user.Id);
        }
    }
}
