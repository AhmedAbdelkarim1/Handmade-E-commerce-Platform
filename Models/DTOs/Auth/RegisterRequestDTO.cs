using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Auth
{
	public class RegisterRequestDTO
	{
		public string UserName { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string UserType { get; set; }

		public bool? HasWhatsApp { get; set; }
		public string? Address { get; set; }
		public string? MobileNumber { get; set; }
		public string? NationalId { get; set; } 
		public string? Bio { get; set; } 
	}
}
