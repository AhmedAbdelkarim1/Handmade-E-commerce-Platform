namespace Models.Domain
{
	public class Category : BaseModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? ImageId { get; set; }
		public Image Image { get; set; }

		public ICollection<Service> Services { get; set; }
	}
}
