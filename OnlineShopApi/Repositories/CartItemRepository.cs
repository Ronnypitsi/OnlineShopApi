using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Data.Entities;
using OnlineShopApi.Interfaces;

namespace OnlineShopApi.Repositories
{
	public class CartItemRepository : ICartItemRepository
	{
		 private readonly OrderContext _orderContext;
		public CartItemRepository(OrderContext orderContext) 
		{
			_orderContext= orderContext;
		}
		public async void AddAsync(CartItem entity)
		{
			_orderContext.CartItem.Add(entity);
		}

		public void DeleteAsync(int id)
		{
			var cartItem = _orderContext.CartItem.Find(id);
			_orderContext.CartItem.Remove(cartItem);
		}

		public async Task<IEnumerable<CartItem>> GetAllAsync()
		{
			return await _orderContext.CartItem.ToListAsync();
		}

		public async Task<CartItem> GetByIdAsync(int id)
		{
			return await _orderContext.CartItem.FirstAsync(x => x.Id == id);
		}

	

	}
}
