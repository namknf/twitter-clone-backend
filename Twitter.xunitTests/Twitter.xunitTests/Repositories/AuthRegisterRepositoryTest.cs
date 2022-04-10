namespace Twitter.xunitTests.Repositories
{
    using JetBrains.dotMemoryUnit;
    using Xunit;
    using Twitter_backend.Data;
    using Twitter_backend.Models;
    using Twitter_backend.Repositories;
    using System;
    using JetBrains.dotMemoryUnit.Kernel;

    public class AuthRegisterRepositoryTest
    {
        private readonly AuthRegisterRepository<User> _authRepo;

        public AuthRegisterRepositoryTest()
        {
            var context = new TwitterContext();
            _authRepo = new AuthRegisterRepository<User>(context);
        }

        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void CanGetAllUsers()
        {
            var users = _authRepo.GetAll();

            Assert.NotEmpty(users);
        }

        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void CanGetUser()
        {
            var id = 1;

            var user = _authRepo.GetById(id);

            Assert.Equal(user.Id, id);
        }

        [Fact]
        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] { typeof(User) })]
        public void DotMemoryUnitTest()
        {
            var context = new TwitterContext();
            var repo = new AuthRegisterRepository<User>(context);

            repo.GetAll();

            if (dotMemoryApi.IsEnabled)
            {
                dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<User>()).ObjectsCount));
            }

            GC.KeepAlive(repo);
        }
    }
}
