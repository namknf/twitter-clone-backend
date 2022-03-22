namespace Twitter_backend.Validators
{
    using FluentValidation;
    using Twitter_backend.Models;

    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(comment => comment.TextComment)
                .NotEmpty()
                .WithMessage("Your comment cannot be empty");
        }
    }
}
