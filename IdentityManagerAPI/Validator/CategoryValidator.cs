using FluentValidation;
using Models.Const;
using Models.DTOs.Categories;
using System.ComponentModel.DataAnnotations;

namespace IdentityManagerAPI.Validator
{
    public class CategoryValidator: AbstractValidator<CategorySearchDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(Errors.RequiredField);
        }
    }
}
