using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopApi.Dtos
{
	public class CartItemDto
	{
		public int Id { get; set; }
		public int ItemId { get; set; }
		public int Quantity { get; set; }
		public decimal Total { get; set; }
		public ItemDto Item { get; set; }
	}
}
