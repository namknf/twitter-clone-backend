namespace Twitter_backend.Validators
{
    using FluentValidation;
    using Twitter_backend.Models;

    public class AuthenticateValidator : AbstractValidator<User>
    {
        public AuthenticateValidator()
        {
            RuleFor(unauthorizedUser => unauthorizedUser.Password)
                .NotEmpty()
                .WithMessage("Please, specify your Password");

            RuleFor(unauthorizedUser => unauthorizedUser.Password)
                .Length(8, 75)
                .WithMessage("The length of password must be not less of 8 characters");

            RuleFor(unauthorizedUser => unauthorizedUser.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$")
                .WithMessage("The password must contain at least one uppercase and lowercase letter, " +
                             "a number and any character.");

            RuleFor(unauthorizedUser => unauthorizedUser.Email)
                .NotEmpty()
                .WithMessage("Please, specify your Email")
                .EmailAddress()
                .WithMessage("Incorrect email-address");
        }
    }
}
