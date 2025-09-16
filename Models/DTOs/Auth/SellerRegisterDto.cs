using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Auth
{
	public class SellerRegisterDto : CustomerRegisterDto
	{
		[Required]
		[MaxLength(14), Display(Name = "National ID"),
			RegularExpression("^[2,3]{1}[0-9]{13}$", ErrorMessage = "Invalid national ID")]

		public string NationalId { get; set; } = null!;

		public string? Bio { get; set; } = null!;
	}
}
