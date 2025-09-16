namespace Models.DTOs.ShoppingCart
{
	public class ShoppingCartDto
	{
		public int Id { get; set; }
		public string CustomerId { get; set; } = null!;
		public List<CartItemDto> Items { get; set; } = new();
	}
}
