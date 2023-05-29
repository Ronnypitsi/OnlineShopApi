using Microsoft.EntityFrameworkCore;

namespace OnlineShopApi.Data.Entities
{
	public class OrderContext: DbContext
	{
		public OrderContext(DbContextOptions<OrderContext> options) : base(options)
		{

		}
		public DbSet<Item> Item { get; set; }
		public DbSet<CartItem> CartItem { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderItem> OrderItem { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var item1 = new Item
			{  Id=1,
				Name = "Sony Wireless Noise-Canceling Headphones WH-1000XM5 - Black",
				Description = "Eligible for next-day delivery or collection.  Free Delivery Available.Hassle-Free Exchanges & Returns for 30 Days. 12-Month Limited Warranty.",
				Price = 7999,
				Image = "./assets/images/sonyH.png",
			};
			var item2 = new Item
			{
				Id=2,
				Name = "P47 Wireless Bluetooth Headphones",
				Description = "Hassle-Free Exchanges & Returns for 30 Days.6-Month Limited Warranty",
				Price = 138,
				Image = "./assets/images/p47.png",
			};
			var item3 = new Item
			{
				Id=3,
				Name = "F9 TWS Earbuds",
				Description = "Eligible for next-day delivery or collection.Eligible for Cash on Delivery.Hassle-Free Exchanges & Returns for 30 Days.6-Month Limited Warranty.",
				Price = 212,
				Image = "./assets/images/f9.png",
			};
			var item4 = new Item
			{
				Id=4,
				Name = "Amplify True Wireless Sports Earphones - True Tunes Series - Black",
				Description = "Eligible for next-day delivery or collection.  Free Delivery Available.Hassle-Free Exchanges & Returns for 30 Days. 12-Month Limited Warranty.",
				Price = 199,
				Image = "./assets/images/amp.png",
			};
			modelBuilder.Entity<Item>().HasData(item1, item2, item3, item4);
			base.OnModelCreating(modelBuilder);
		}

	}
}
