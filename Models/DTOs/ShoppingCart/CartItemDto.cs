namespace Models.DTOs.ShoppingCart
{
	public class CartItemDto
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string ProductTitle { get; set; } = null!;
		public string ProductImageUrl { get; set; } = null!;
		public string ArtisanName { get; set; } = "Unknown";
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice => Quantity * UnitPrice;
		public int inStock { get; set; }
	}
}
