using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Service
{
	public class UpdateServiceReason
	{
		[Required]
		public string? Reason { get; set; }
	}
}
