namespace Twitter_backend.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorizeRequest
    {
        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
