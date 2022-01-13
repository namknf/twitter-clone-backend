namespace Twitter_backend.Models
{
    using System;

    public class User
    {
        public int Id { get; init; }

        public string Email { get; set; }

        public int Password { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string Description { get; set; }

        public DateTime DateProfile { get; init; }

        public User[] TweetsId { get; init; }

        public User[] Followers { get; init; }

        public User[] Following { get; init; }
    }
}
