﻿using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Ecommerce.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string? Category { get; set; }
		[Required]
		[MaxLength(50)]
		public string? Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
		[MaxLength(500)]
		public string? ShippingInfo { get; set; }
		[Required]
		[MaxLength(20)]
		public string? OldPrice { get; set; }
		[Required]
		[MaxLength(20)]
		public string? CurrentPrice { get; set; }
		public int? StockQuantity { get; set; }


		public ICollection<MyImage>? MyImages { get; set; }
		public ICollection<MyItem>? MyItems { get; set; }
	}
}
