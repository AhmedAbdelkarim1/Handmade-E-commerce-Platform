using IdentityManager.Services.ControllerService.IControllerService;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Auth;

namespace IdentityManagerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokensController : ControllerBase
	{
		private readonly IAuthService _authService;

		public TokensController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
		{
			var result = await _authService.LoginAsync(loginRequestDTO);
			return Ok(result);
		}
	}
}
