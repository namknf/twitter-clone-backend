#nullable disable

namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// .
    /// </summary>
    public partial class User : ModelBase
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Tweets = new HashSet<Tweet>();
        }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }

        public virtual ICollection<User> Followers { get; set; }

        public virtual ICollection<User> Following { get; set; }
    }
}
