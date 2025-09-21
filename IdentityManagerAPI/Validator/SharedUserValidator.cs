using DataAcess.Repos.IRepos;
using FluentValidation;
using Models.Const;
using Models.DTOs.Auth;

namespace IdentityManagerAPI.Validator
{
    public class SharedUserValidator : AbstractValidator<RegisterRequestDTO>
    {
        private readonly IUserRepository _userRepository;

        public SharedUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(u => u.HasWhatsApp)
                .NotNull().WithMessage(Errors.RequiredField);

            RuleFor(u => u.Address).NotEmpty().WithMessage(Errors.RequiredField)
            .MaximumLength(500).WithMessage(Errors.MaxLength);

            RuleFor(u => u.MobileNumber)
            .NotEmpty().WithMessage(Errors.RequiredField)
            .MaximumLength(11).WithMessage(Errors.MaxLength)
            .Matches(RegexPatterns.MobileNumber).WithMessage(Errors.InvalidMobileNumber)
            .MustAsync(async (mobile, cancellationToken) =>
            !await _userRepository.IsExistsAsync(u => u.PhoneNumber == mobile))
            .WithMessage(Errors.Duplicated);
        }
    }
}
