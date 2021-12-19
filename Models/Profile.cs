namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using BC = BCrypt.Net.BCrypt;

    public class Profile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the correct nickname")]
        public string NickName { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateProfile { get; }

        public User UserId { get; set; }

        public Tweet[] TweetsId { get; set; }

        public Profile[] Followers { get; set; }

        public Profile[] Following { get; set; }
    }
}
