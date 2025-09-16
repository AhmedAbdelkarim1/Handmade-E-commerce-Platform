using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
	public class UpdateProductStatusDTO
	{
		[Required]
		public string Status { get; set; } = string.Empty;

	}
}
