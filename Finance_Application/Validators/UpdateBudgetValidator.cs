using Finance_Core.DTOs;
using FluentValidation;

namespace Finance_Application.Validators;
public class UpdateBudgetValidator : AbstractValidator<BudgetDTO>
{
    public UpdateBudgetValidator()
    {
        RuleFor(b => b.id)
            .GreaterThan(0)
            .WithMessage("The ID must be greater than zero.");

        RuleFor(b => b.user_id)
            .GreaterThan(0)
            .WithMessage("The User ID must be greater than zero.");

        RuleFor(b => b.category_id)
            .GreaterThan(0)
            .WithMessage("The Category ID must be greater than zero.");

        RuleFor(b => b.amount)
            .GreaterThan(0)
            .WithMessage("The Amount must be greater than zero.");

        RuleFor(b => b.start_date)
            .LessThan(b => b.end_date)
            .WithMessage("The Start Date must be earlier than the End Date.");

        RuleFor(b => b.end_date)
            .GreaterThan(b => b.start_date)
            .WithMessage("The End Date must be later than the Start Date.");

        RuleFor(b => b.created_at)
            .NotEmpty()
            .WithMessage("The Created At date cannot be empty.")
            .Must(date => date <= DateTime.UtcNow)
            .WithMessage("The Created At date cannot be in the future.");
    }
}
