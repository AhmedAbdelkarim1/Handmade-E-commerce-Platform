namespace Models.DTOs.Categories
{
	public class CategoryDto // get
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? ImageUrl { get; set; }
		public int serviceCount { get; set; }
	}
}
