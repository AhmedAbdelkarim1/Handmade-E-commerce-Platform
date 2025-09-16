using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Models.DTOs.image
{
	public class ImageUploadRequestDto
	{
		[Required]
		public IFormFile? ProfileImage { get; set; } = null!;
		[Required]
		public IFormFile? IdCardImage { get; set; } = null!;
	}
}
