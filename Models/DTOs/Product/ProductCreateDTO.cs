using Microsoft.AspNetCore.Http;

namespace Models.DTOs
{
	public class ProductCreateDTO
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public IFormFile File { get; set; } = null!;
		public int ServiceId { get; set; }

	}
}
