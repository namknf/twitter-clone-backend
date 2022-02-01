namespace Twitter_backend.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorizeRequest
    {
        [Required]
        public string Email { get; init; }

        [Required]
        public string PasswordHash { get; init; }
    }
}
