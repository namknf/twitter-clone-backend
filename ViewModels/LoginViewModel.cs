namespace Twitter_backend.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; init; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; init; }

        [Display(Name = "Remmember?")]
        public bool RemmemberMe { get; init; }

        public string ReturnUrl { get; init; }
    }
}
