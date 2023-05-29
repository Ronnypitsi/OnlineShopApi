using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopApi.Data.Entities
{
	
	[Table("CartItem")]
	public class CartItem
	{
		[Key]
		public int Id { get; set; }
		[Required, Unicode(false), MaxLength(25)]
		public int ItemId { get; set; }
		public int Quantity { get; set; }
		public DateTime Date { get; set; }
	}

}
