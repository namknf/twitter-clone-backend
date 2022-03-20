namespace Twitter.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using NUnit.Framework;
    using Twitter_backend.Models;
    using Twitter_backend.Validators;

    [TestFixture]
    public class AuthenticateValidatorTests
    {
        private AuthenticateValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new AuthenticateValidator();
        }

        [Test]
        public void ShouldBeErrorWhenPasswordIsNull()
        {
            var model = new User { Password = null };
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(user => user.Password);
        }

        [Test]
        public void ShouldNasNoErrorWhenPasswordIsSpecified()
        {
            var model = new User { Password = "Adf56Hgsjiq&" };
            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(user => user.Password);
        }

        [Test]
        public void ShouldBeErrorWhenPasswordIsSmallOrDoNotMatch()
        {
            var model = new User { Password = "Adf" };
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(user => user.Password);
        }
    }
}
