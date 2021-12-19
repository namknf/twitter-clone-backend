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

        public int Password { get; set; }
    }
}
