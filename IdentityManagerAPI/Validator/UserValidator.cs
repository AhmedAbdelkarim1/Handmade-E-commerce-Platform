using FluentValidation;
using Models.Const;
using Models.DTOs.Auth;

namespace IdentityManagerAPI.Validator
{
	public class UserValidator : AbstractValidator<RegisterRequestDTO>
	{
		public UserValidator()
		{
			RuleFor(u => u.UserName)
				.NotEmpty().WithMessage(Errors.RequiredField)
				.MinimumLength(3).WithMessage(Errors.MinLength)
				.Matches(RegexPatterns.NumbersAndChrOnly_ArEng).WithMessage(Errors.OnlyNumbersAndLetters);

			RuleFor(u => u.Name)
				.NotEmpty().WithMessage(Errors.RequiredField)
				.MinimumLength(3).WithMessage(Errors.MinLength)
				.Matches(RegexPatterns.CharactersOnly_Eng).WithMessage(Errors.OnlyEnglishLetters);

			RuleFor(u => u.Email)
				.NotEmpty().WithMessage(Errors.RequiredField)
				.MaximumLength(120).WithMessage(Errors.MaxLength)
				.EmailAddress();

			RuleFor(u => u.Password)
				.NotEmpty().WithMessage(Errors.RequiredField)
				.Matches(RegexPatterns.Password).WithMessage(Errors.WeakPassword);

			RuleFor(u => u.UserType)
				.NotEmpty().WithMessage(Errors.RequiredField)
				.Must(BeValidUserType).WithMessage(Errors.TypeError);

			When(u => u.UserType.ToLower() == AppRoles.Customer.ToLower(), () => {
				RuleFor(u => u.HasWhatsApp).NotNull().WithMessage(Errors.RequiredField);

				RuleFor(u => u.Address).NotEmpty().WithMessage(Errors.RequiredField)
				.MaximumLength(500).WithMessage(Errors.MaxLength);

				RuleFor(u => u.MobileNumber).NotEmpty().WithMessage(Errors.RequiredField)
				.MaximumLength(11).WithMessage(Errors.MaxLength)
				.Matches(RegexPatterns.MobileNumber).WithMessage(Errors.InvalidMobileNumber);
			});

			When(u => u.UserType.ToLower() == AppRoles.Seller.ToLower(), () => {
				RuleFor(u => u.HasWhatsApp).NotNull().WithMessage(Errors.RequiredField);

				RuleFor(u => u.Address).NotEmpty().WithMessage(Errors.RequiredField)
				.MaximumLength(500).WithMessage(Errors.MaxLength);

				RuleFor(u => u.MobileNumber).NotEmpty().WithMessage(Errors.RequiredField)
				.MaximumLength(11).WithMessage(Errors.MaxLength)
				.Matches(RegexPatterns.MobileNumber).WithMessage(Errors.InvalidMobileNumber);

				RuleFor(u => u.NationalId).NotEmpty().WithMessage(Errors.RequiredField)
				.MaximumLength(14).WithMessage(Errors.MaxLength)
				.Matches(RegexPatterns.NationalId).WithMessage(Errors.InvalidNationalId);

				RuleFor(u => u.Bio).NotEmpty().WithMessage(Errors.RequiredField)
				.Length(20,100).WithMessage(Errors.MaxMinLength);
			});

		}

		private bool BeValidUserType(string userType)
		{
			string type = userType.ToLower();
			return type == AppRoles.Admin.ToLower() || type == AppRoles.Seller.ToLower() || type == AppRoles.Customer.ToLower();
		}
	}
}
