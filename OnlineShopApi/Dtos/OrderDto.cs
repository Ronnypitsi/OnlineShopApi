using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopApi.Dtos
{
	public class OrderDto
	{
		public int Id { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime Date { get; set; }
	}
}
