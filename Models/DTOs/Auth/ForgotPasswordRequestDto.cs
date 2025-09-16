using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Auth
{
	public class ForgotPasswordRequestDto
	{
		[Required]
		public string Email { get; set; } = string.Empty;
	}
}
