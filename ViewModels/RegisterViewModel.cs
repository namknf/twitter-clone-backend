namespace Twitter_backend.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; init; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; init; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; init; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords mismatch")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; init; }
    }
}
