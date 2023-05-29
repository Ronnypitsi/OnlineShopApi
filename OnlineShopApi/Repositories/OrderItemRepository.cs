using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Data.Entities;
using OnlineShopApi.Interfaces;

namespace OnlineShopApi.Repositories
{
	public class OrderItemRepository : IOrderItemRepository
	{
		private readonly OrderContext _orderContext;
		public OrderItemRepository(OrderContext orderContext)
		{
			_orderContext = orderContext;
		}
		public async void AddAsync(OrderItem entity)
		{
			_orderContext.OrderItem.Add(entity);
		}

		public void DeleteAsync(int id)
		{
			var orderItem = _orderContext.OrderItem.Find(id);
			_orderContext.OrderItem.Remove(orderItem);
		}

		public async Task<IEnumerable<OrderItem>> GetAllAsync()
		{
			return await _orderContext.OrderItem.ToListAsync();
		}

		public async Task<OrderItem> GetByIdAsync(int id)
		{
			return await _orderContext.OrderItem.FirstAsync(x => x.Id == id);
		}

		
		
	}
}
