using OnlineShopApi.Repositories;

namespace OnlineShopApi.Interfaces
{
	public interface IUnitOfWork
	{
		IOrderRepository OrderRepository { get; }
		 IItemRepository ItemRepository { get; }
		IOrderItemRepository OrderItemRepository { get; }
		ICartItemRepository CartItemRepository { get; }

		Task<bool> SaveAsync();
	}
}
