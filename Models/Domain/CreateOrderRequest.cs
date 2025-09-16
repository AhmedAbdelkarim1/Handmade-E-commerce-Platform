namespace Models.Domain
{
	public class CreateOrderRequest
	{
		public string? CustomerId { get; set; }
		public string PhoneNumber { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string PaymentMethod { get; set; } = null!; // e.g. "Cash", "Credit Card"
	}
}
