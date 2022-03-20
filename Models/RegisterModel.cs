namespace Twitter_backend.Models
{
    public class RegisterModel : ModelBase
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
