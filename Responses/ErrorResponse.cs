namespace Twitter_backend.Responses
{
    using System.Collections.Generic;
    using Twitter_backend.Models;

    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new();
    }
}
