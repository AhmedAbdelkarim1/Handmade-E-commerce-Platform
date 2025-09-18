using IdentityManager.Services.ControllerService.IControllerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Auth;

namespace IdentityManagerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PasswordsController : ControllerBase
	{
		private readonly IAuthService _authService;

		public PasswordsController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("reset-password-requests")]
		public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto request)
		{
			var result = await _authService.ForgotPasswordAsync(request);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto request)
		{
			var result = await _authService.ResetPasswordAsync(request);
			return Ok(result);
		}

	}
}
