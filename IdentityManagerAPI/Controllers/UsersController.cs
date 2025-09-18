using System.Security.Claims;
using DataAcess;
using DataAcess.Repos.IRepos;
using IdentityManager.Services.ControllerService;
using IdentityManager.Services.ControllerService.IControllerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTOs.Auth;
using Models.DTOs.image;

namespace IdentityManagerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly IAuthService _authService;

		public UsersController(IUserService userService, IAuthService authService)
		{
			this.userService = userService;
			_authService = authService;
		}

		[HttpGet]
		//[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAllUsers([FromQuery] string? status)
		{
			var users = await userService.GetAllUsers(status);
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUser([FromRoute] string id)
		{
			var user = await userService.GetById(id);
			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
		{
			var result = await _authService.RegisterAdminAsync(registerRequestDTO);
			return Ok(result);
		}

		[HttpPut("{sellerId}/status")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> EditSellerStatus([FromRoute] string sellerId, [FromBody] UpdateOrderItemStatusRequest request)
		{
			await userService.ChangeSellerStatus(sellerId, request.Status);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteUser([FromRoute] string id)
		{
			await userService.DeleteUser(id);
			return NoContent();
		}

		[HttpGet("me/status")]
		public async Task<IActionResult> GetCurrentUserStatus()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var status = await userService.GetSellerStatus(userId!);
			return Ok(new { status });
		}

		[HttpPost]
		[Authorize]
		[Route("me/image")]
		public async Task<IActionResult> UploadUserImage([FromForm] ImageUploadRequestDto request)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var result = await userService.UploadUserImageAsync(userId!, request);
			return Ok(result);
		}
	}
}