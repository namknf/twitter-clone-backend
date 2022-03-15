namespace Twitter_backend.Entities
{
    using System.Collections.Generic;
    using Twitter_backend.Models;

    public class AuthorizeResponse
    {
        public AuthorizeResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            NickName = user.NickName;
            Description = user.Description;
            Tweets = user.Tweets;
            Followers = user.Followers;
            Following = user.Following;
            Token = token;
        }

        public int Id { get; init; }

        public string Name { get; init; }

        public string Email { get; init; }

        public string NickName { get; init; }

        public string Description { get; init; }

        public ICollection<Tweet> Tweets { get; init; }

        public ICollection<User> Followers { get; init; }

        public ICollection<User> Following { get; init; }

        public string Token { get; set; }
    }
}
