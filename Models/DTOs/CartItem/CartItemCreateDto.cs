namespace Models.DTOs.CartItem
{
	public class CartItemCreateDto
	{
		public int CartId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
