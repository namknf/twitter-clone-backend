namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the correct E-mail")]
        public string Email { get; set; }

        [Range(8, 79, ErrorMessage = "Password must contain at least 8 characters and no more than 79")]
        [Required(ErrorMessage = "Enter the correct password")]
        public int Password { get; set; }
    }
}
