using Finance_Core.DTOs;
using FluentValidation;

namespace Finance_Application.Validators;
public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
{
	public CategoryDTOValidator()
	{
        RuleFor(x => x.name)
            .NotEmpty().WithMessage("The name is required.")
            .Length(2, 50).WithMessage("The name must be between 2 and 50 characters.");

        RuleFor(x => x.type)
            .NotEmpty().WithMessage("The type is required.")
            .IsInEnum().WithMessage("The type must be a valid number.");
    }
}
