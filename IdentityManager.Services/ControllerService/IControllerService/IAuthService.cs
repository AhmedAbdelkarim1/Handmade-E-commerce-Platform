using Models.DTOs.Auth;

namespace IdentityManager.Services.ControllerService.IControllerService
{
	public interface IAuthService
	{
		Task<object> LoginAsync(LoginRequestDTO loginRequestDTO);
		Task<object> RegisterAdminAsync(RegisterRequestDTO registerRequestDTO);
		Task<object> RegisterSellerAsync(SellerRegisterDto sellerRegistertDTO);
		Task<object> RegisterCustomerAsync(CustomerRegisterDto customerRegistertDTO);
		Task<object> ForgotPasswordAsync(ForgotPasswordRequestDto forgotPasswordRequestDto);
		Task<object> ResetPasswordAsync(ResetPasswordRequestDto resetPasswordRequestDto);

	}
}
