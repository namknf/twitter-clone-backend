namespace Twitter_backend.Validators
{
    using FluentValidation;
    using Twitter_backend.Models;

    public class TweetValidator : AbstractValidator<Tweet>
    {
        public TweetValidator()
        {
            RuleFor(tweet => tweet.Text)
                .NotEmpty()
                .WithMessage("You cannot public the empty tweet");
        }
    }
}
