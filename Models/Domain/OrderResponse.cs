namespace Models.Domain
{
	public class OrderResponse
	{
		public int Id { get; set; }
		public string CustomerName { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public List<OrderItemResponse> Items { get; set; } = new();
		public decimal TotalPrice { get; set; }
	}
}
