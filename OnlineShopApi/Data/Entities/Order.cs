using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopApi.Data.Entities
{

	[Table("Order")]
	public class Order
	{
		[Key]
		public int Id { get; set; }
		[Required, Unicode(false), MaxLength(25)]
		public decimal TotalPrice { get; set; }

		public DateTime Date { get; set; }
	}
}
