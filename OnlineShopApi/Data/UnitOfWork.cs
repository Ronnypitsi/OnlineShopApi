using OnlineShopApi.Data.Entities;
using OnlineShopApi.Interfaces;
using OnlineShopApi.Repositories;

namespace OnlineShopApi.Data
{
	public class UnitOfWork:IUnitOfWork
	{ 

		 private readonly OrderContext _orderContext;
	
		public UnitOfWork(OrderContext orderContext) 
		{
			_orderContext=orderContext;
		}

		public IOrderRepository OrderRepository => new OrderRepository(_orderContext);

		public IItemRepository ItemRepository => new ItemRepository(_orderContext);

		public IOrderItemRepository OrderItemRepository =>  new OrderItemRepository(_orderContext);

		public ICartItemRepository CartItemRepository =>new CartItemRepository(_orderContext);

		public async Task<bool> SaveAsync()
		{
			return await _orderContext.SaveChangesAsync() > 0;
		}
	}
}
