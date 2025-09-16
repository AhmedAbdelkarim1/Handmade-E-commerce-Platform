using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Auth
{
	public class LoginRequestDTO
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
