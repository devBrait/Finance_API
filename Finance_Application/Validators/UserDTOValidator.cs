using Finance_Core.DTOs;
using FluentValidation;

namespace Finance_Application.Validators;
public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(user => user.name)
            .NotEmpty().WithMessage("The name is required.")
            .Length(2, 50).WithMessage("The name must be between 2 and 50 characters.");

        RuleFor(user => user.email)
            .NotEmpty().WithMessage("The email is required.")
            .EmailAddress().WithMessage("The email must be valid.");

        RuleFor(user => user.password)
            .NotEmpty().WithMessage("The password is required.")
            .MinimumLength(6).WithMessage("The password must be at least 6 characters long.");
    }
}
