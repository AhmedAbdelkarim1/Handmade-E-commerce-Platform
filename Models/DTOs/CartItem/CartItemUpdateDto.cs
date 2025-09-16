namespace Models.DTOs.CartItem
{
	public class CartItemUpdateDto
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
