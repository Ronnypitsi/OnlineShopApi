using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopApi.Data.Entities
{
	
		[Table("Item")]
		public class Item
		{
			[Key]
			public int Id { get; set; }
			[Required, MaxLength(100)]
			public string Name { get; set; }
			[Required]
			public string Description { get; set; }
			[Required]
			public decimal Price { get; set; }
			public DateTime Date { get; set; }
		   public string Image { get; set; }
	    }
	

}
