namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;

    public class User : ModelBase
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string Description { get; set; }

        public DateTime DateProfile { get; }

        public ICollection<Tweet> Tweets { get; set; }

        public ICollection<User> Followers { get; set; }

        public ICollection<User> Following { get; set; }
    }
}
