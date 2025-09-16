using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Service
{
	public class UpdateServiceStatusDTO
	{
		[Required]
		public string Status { get; set; } = string.Empty;
	}
}
