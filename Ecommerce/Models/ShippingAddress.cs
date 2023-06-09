﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Ecommerce.Models
{
	public class ShippingAddress
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string? FirstName { get; set; }
		[Required]
		[MaxLength(20)]
		public string? LastName { get; set; }
		[Required]
		[MaxLength(50)]
		public string? Address { get; set; }
		[Required]
		[MaxLength(50)]
		public string? City { get; set; }
		[Required]
		[MaxLength(10)]
		public string? PostCode { get; set; }
		[Required]
		[MaxLength(50)]
		public string? Country { get; set; }



		[ForeignKey("MyOrder")]
		public int MyOrderId { get; set; }
		public MyOrder? MyOrder { get; set; }
	}
}
