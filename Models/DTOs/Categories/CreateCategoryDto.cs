using Microsoft.AspNetCore.Http;

namespace Models.DTOs.Categories
{
	public class CreateCategoryDto
	{
		public string Name { get; set; }
		public IFormFile? File { get; set; }

	}
}
