using Finance_Core.DTOs;
using FluentValidation;

namespace Finance_Application.Validators;
public class TransactionDTOValidator : AbstractValidator<TransactionDTO>
{
	public TransactionDTOValidator()
    {
        RuleFor(x => x.user_id)
            .NotEmpty().WithMessage("The user id is required.")
            .IsInEnum().WithMessage("The user id must be a valid number.");

        RuleFor(x => x.category_id)
            .NotEmpty().WithMessage("The category id is required.")
            .IsInEnum().WithMessage("The category id must be a valid number.");

        RuleFor(x => x.amount)
            .NotEmpty().WithMessage("The amount is required.");
    }
}
