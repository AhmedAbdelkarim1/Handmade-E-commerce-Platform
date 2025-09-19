using Models.DTOs.Auth;
using Models.DTOs.User;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface IAuthService
	{
		Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
		Task<UserDTO> RegisterAsync(RegisterRequestDTO registerRequestDTO);
		Task<object> ForgotPasswordAsync(ForgotPasswordRequestDto forgotPasswordRequestDto);
		Task<object> ResetPasswordAsync(ResetPasswordRequestDto resetPasswordRequestDto);
	}
}
