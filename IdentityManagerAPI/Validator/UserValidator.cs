using DataAcess.Repos.IRepos;
using FluentValidation;
using Models.Const;
using Models.DTOs.Auth;

namespace IdentityManagerAPI.Validator
{
	public class UserValidator : AbstractValidator<RegisterRequestDTO>
	{
		private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            _userRepository = userRepository;

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage(Errors.RequiredField)
                .MinimumLength(3).WithMessage(Errors.MinLength)
                .Matches(RegexPatterns.NumbersAndChrOnly_ArEng).WithMessage(Errors.OnlyNumbersAndLetters)

                .MustAsync(async (username, cancellationToken) =>
                !await _userRepository.IsExistsAsync(u => u.UserName == username))
                .WithMessage(Errors.Duplicated);
                
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage(Errors.RequiredField)
                .MinimumLength(3).WithMessage(Errors.MinLength)
                .Matches(RegexPatterns.CharactersOnly_Eng).WithMessage(Errors.OnlyEnglishLetters);

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage(Errors.RequiredField)
                .MaximumLength(120).WithMessage(Errors.MaxLength)
                .EmailAddress()

                .MustAsync(async (email, cancellationToken) =>
                !await _userRepository.IsExistsAsync(u => u.Email == email))
                .WithMessage(Errors.Duplicated);

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(Errors.RequiredField)
                .Matches(RegexPatterns.Password).WithMessage(Errors.WeakPassword);

            RuleFor(u => u.UserType)
                .NotEmpty().WithMessage(Errors.RequiredField)
                .Must(BeValidUserType).WithMessage(Errors.TypeError);

            When(u => u.UserType.ToLower() == AppRoles.Customer.ToLower(), () =>
            {
                Include(new SharedUserValidator(_userRepository));
            });

            When(u => u.UserType.ToLower() == AppRoles.Seller.ToLower(), () =>
            {
                Include(new SharedUserValidator(_userRepository));

                RuleFor(u => u.NationalId)
                .NotEmpty().WithMessage(Errors.RequiredField)
                .MaximumLength(14).WithMessage(Errors.MaxLength)
                .Matches(RegexPatterns.NationalId).WithMessage(Errors.InvalidNationalId)
                .MustAsync(async (nationalId, cancellationToken) =>
                !await _userRepository.IsExistsAsync(u => u.NationalId == nationalId))
                .WithMessage(Errors.Duplicated);

                RuleFor(u => u.Bio)
                .NotEmpty().WithMessage(Errors.RequiredField)
                .Length(20, 100).WithMessage(Errors.MaxMinLength);
            });
        }

        private bool BeValidUserType(string userType)
		{
			string type = userType.ToLower();
			return type == AppRoles.Admin.ToLower() || type == AppRoles.Seller.ToLower() || type == AppRoles.Customer.ToLower();
		}
	}
}
