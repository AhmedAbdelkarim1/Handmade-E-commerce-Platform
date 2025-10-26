using DataAcess.Repos.IRepos;
using FluentValidation;
using Models.Const;
using Models.DTOs.Categories;
using System.ComponentModel.DataAnnotations;

namespace IdentityManagerAPI.Validator
{
    public class CategoryValidator: AbstractValidator<CategorySearchDto>
    {
        private readonly ICategoryRepository _categoryRepostatory;

        public CategoryValidator(ICategoryRepository categoryRepostatory)
        {
            _categoryRepostatory = categoryRepostatory;

            RuleFor(c => c.Name)
                .MaximumLength(100).WithMessage(Errors.MaxLength)
                .Matches(RegexPatterns.CharactersOnly_Eng).WithMessage(Errors.OnlyEnglishLetters);
        }
    }
}
