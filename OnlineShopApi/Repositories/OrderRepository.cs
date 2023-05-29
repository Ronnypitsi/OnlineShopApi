using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Data.Entities;
using OnlineShopApi.Interfaces;

namespace OnlineShopApi.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly OrderContext _orderContext;
		public OrderRepository(OrderContext orderContext)
		{
			_orderContext = orderContext;
		}
		public void AddAsync(Order entity)
		{
			_orderContext.Order.Add(entity);
		}

		public void DeleteAsync(int id)
		{
			var order = _orderContext.Order.Find(id);
			_orderContext.Order.Remove(order);
		}

		public async Task<IEnumerable<Order>> GetAllAsync()
		{
			return await _orderContext.Order.ToListAsync();
		}

		public async Task<Order> GetByIdAsync(int id)
		{
			return await _orderContext.Order.FirstAsync(x => x.Id == id);
		}

		
		
	}
}
