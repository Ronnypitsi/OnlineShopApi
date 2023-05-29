using OnlineShopApi.Data.Entities;

namespace OnlineShopApi.Interfaces
{
    public interface IItemRepository
	{
		void AddAsync(Item entity);
		Task<Item> GetByIdAsync(int id);
		Task<IEnumerable<Item>> GetAllAsync();

		void DeleteAsync(int id);

	}
}
