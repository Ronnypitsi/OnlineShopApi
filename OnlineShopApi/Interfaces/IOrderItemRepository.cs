using OnlineShopApi.Data.Entities;

namespace OnlineShopApi.Interfaces
{
    public interface IOrderItemRepository
    {
		void AddAsync(OrderItem entity);
		Task<OrderItem> GetByIdAsync(int id);
		Task<IEnumerable<OrderItem>> GetAllAsync();

		void DeleteAsync(int id);

		
	}
}
