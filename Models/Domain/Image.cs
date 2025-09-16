using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Models.Domain
{
	public class Image
	{
		public int Id { get; set; }
		[NotMapped]
		public IFormFile File { get; set; } = null!;
		public string FileName { get; set; } = null!;
		public string FileExtension { get; set; } = null!;
		public long FileSize { get; set; }
		public string FilePath { get; set; } = null!;

	}
}
