﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain
{
	public class OrderItem
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Order")]
		public int OrderId { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }

		public int Quantity { get; set; }

		public decimal UnitPrice { get; set; }

		// Navigation properties
		public Order Order { get; set; }

		public Product? Product { get; set; }
	}
}
