using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Ardalis.GuardClauses;
using FluentValidation;
using IdentityManager.Services.ControllerService.IControllerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTOs.Auth;
using Models.DTOs.image;
using ValidationException = FluentValidation.ValidationException;

namespace IdentityManagerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly IAuthService _authService;
		private readonly IValidator<RegisterRequestDTO> _validator;

        public UsersController(IUserService userService, IAuthService authService, IValidator<RegisterRequestDTO> validator)
        {
            this.userService = userService;
            _authService = authService;
            _validator = validator;
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
			var ValidationResult = await _validator.ValidateAsync(registerRequestDTO);
            if (!ValidationResult.IsValid)
				throw new ValidationException(ValidationResult.Errors);	

            var result = await _authService.RegisterAsync(registerRequestDTO);
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