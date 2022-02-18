namespace Twitter_backend.Models
{
    using System;

    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string Description { get; set; }

        public DateTime DateProfile { get; set; }

        public Tweet[] Tweets { get; set; }

        public User[] Followers { get; set; }

        public User[] Following { get; set; }
    }
}
