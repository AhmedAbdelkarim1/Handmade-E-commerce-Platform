using Microsoft.AspNetCore.Http;

namespace Models.DTOs.Categories
{

	public class UpdateCategoryDto
	{
		public string Name { get; set; }
		public IFormFile? File { get; set; }
	}

}
