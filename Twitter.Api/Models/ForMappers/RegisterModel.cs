namespace Twitter_backend.Models.ForMappers
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
