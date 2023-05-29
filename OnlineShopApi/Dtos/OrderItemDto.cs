﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopApi.Dtos
{
	public class OrderItemDto
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ItemId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}
