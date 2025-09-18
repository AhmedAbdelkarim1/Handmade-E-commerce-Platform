using Models.DTOs.Auth;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface IAuthService
	{
		Task<object> LoginAsync(LoginRequestDTO loginRequestDTO);
		Task<object> RegisterAdminAsync(RegisterRequestDTO registerRequestDTO);
		Task<object> RegisterSellerAsync(RegisterRequestDTO sellerRegistertDTO);
		Task<object> RegisterCustomerAsync(RegisterRequestDTO customerRegistertDTO);
		Task<object> ForgotPasswordAsync(ForgotPasswordRequestDto forgotPasswordRequestDto);
		Task<object> ResetPasswordAsync(ResetPasswordRequestDto resetPasswordRequestDto);

	}
}
