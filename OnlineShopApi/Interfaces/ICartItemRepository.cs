using OnlineShopApi.Data.Entities;

namespace OnlineShopApi.Interfaces
{
    public interface ICartItemRepository
	{
		void AddAsync(CartItem entity);
		Task<CartItem> GetByIdAsync(int id);
        Task<IEnumerable<CartItem>> GetAllAsync();
       
        void DeleteAsync(int id);

       
    }
}
