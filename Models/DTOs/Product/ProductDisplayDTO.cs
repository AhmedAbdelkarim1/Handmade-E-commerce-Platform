﻿namespace Models.DTOs
{
	public class ProductDisplayDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public string Status { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string SellerId { get; set; } = null!;
		public string? SellerName { get; set; } = null!;
		public int ServiceId { get; set; }
		public string? ImageUrl { get; set; }
		public string Category { get; set; } = null!;
		public string RejectionReason { get; set; } = string.Empty;

	}
}
