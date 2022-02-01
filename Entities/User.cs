namespace Twitter_backend.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; init; }

        [Required(ErrorMessage = "Enter the correct E-mail")]
        public string Email { get; set; }

        [Range(8, 79, ErrorMessage = "Password must contain at least 8 characters and no more than 79")]
        [Required(ErrorMessage = "Enter the correct password")]
        public int Password { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the correct nickname")]
        public string NickName { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateProfile { get; }

        public User[] TweetsId { get; set; }

        public User[] Followers { get; set; }

        public User[] Following { get; set; }
    }
}
