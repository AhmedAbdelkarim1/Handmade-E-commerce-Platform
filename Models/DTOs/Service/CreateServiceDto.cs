using Microsoft.AspNetCore.Http;

namespace Models.DTOs.Service
{
	public class CreateServiceDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal BasePrice { get; set; }
		public int DeliveryTime { get; set; }
		public int CategoryId { get; set; }
		public IFormFile? File { get; set; }
	}
}
