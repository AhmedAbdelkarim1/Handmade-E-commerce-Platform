using System.ComponentModel.DataAnnotations;
using System.Net;
using DataAcess.Repos.IRepos;
using IdentityManager.Services.ControllerService.IControllerService;
using Microsoft.AspNetCore.Identity;
using Models.Const;
using Models.Domain;
using Models.DTOs.Auth;
using Models.DTOs.User;

namespace IdentityManager.Services.ControllerService
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMailingService _mailingService;
		private readonly UserManager<ApplicationUser> _userManager;

		public AuthService(IUserRepository userRepository, IMailingService mailingService, UserManager<ApplicationUser> userManager)
		{
			_userRepository = userRepository;
			_mailingService = mailingService;
			_userManager = userManager;
		}

		public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
		{
			return await _userRepository.Login(loginRequestDTO);
		}		

		public async Task<UserDTO> RegisterAsync(RegisterRequestDTO registerRequestDTO)
		{
			switch (registerRequestDTO.UserType.ToLower())
			{
				case AppRoles.Admin:
					return await _userRepository.RegisterAdmin(registerRequestDTO);

				case AppRoles.Customer:
					return await _userRepository.RegisterCustomer(registerRequestDTO);

				case AppRoles.Seller:
					return await _userRepository.RegisterSeller(registerRequestDTO);

				default:
					throw new ValidationException("Invalid user type.");
            }
		}

		public async Task<object> ForgotPasswordAsync(ForgotPasswordRequestDto forgotPasswordRequestDto)
		{
			var user = await _userRepository.GetAsync(u => u.Email == forgotPasswordRequestDto.Email);
			if (user != null)
			{
				var token = await _userManager.GeneratePasswordResetTokenAsync(user);

				if (string.IsNullOrEmpty(token))
				{
					throw new ValidationException("Some thing went wrong!");
				}

				var callBackUrl = $"http://localhost:4200/reset-password?token={WebUtility.UrlEncode(token)}&email={user.Email}";

				var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\Email.html";
				var str = new StreamReader(filePath);

				var mailText = str.ReadToEnd();
				str.Close();

				mailText = mailText.Replace("[header]", $"Hey, {user.FullName}")
					.Replace("[body]", "Please click the below button to reset your password")
					.Replace("[imageUrl]", "https://res.cloudinary.com/gradbookify/image/upload/v1754135477/icon-positive-vote-2_jcxdww_mo1gkb.svg")
					.Replace("[linkTitle]", "Reset Password")
					.Replace("[url]", callBackUrl);

				await _mailingService.SendEmailAsync(forgotPasswordRequestDto.Email, "Reset Password", mailText);
			}
			return new
			{
			};
		}

		public Task<object> ResetPasswordAsync(ResetPasswordRequestDto resetPasswordRequestDto)
		{
			var user = _userRepository.GetAsync(u => u.Email == resetPasswordRequestDto.Email);
			if (user == null)
			{
				throw new ValidationException("User with this email does not exist.");
			}
			var result = _userManager.ResetPasswordAsync(user.Result, resetPasswordRequestDto.Token, resetPasswordRequestDto.NewPassword);
			if (!result.Result.Succeeded)
			{
				throw new ValidationException("Reset password failed.");
			}
			return Task.FromResult<object>(new { message = "Password reset successfully." });
		}
    }
}
