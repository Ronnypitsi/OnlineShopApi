using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Data.Entities;
using OnlineShopApi.Interfaces;

namespace OnlineShopApi.Repositories
{
	public class ItemRepository: IItemRepository
	{
		private readonly OrderContext _orderContext;
		public ItemRepository(OrderContext orderContext)
		{
			_orderContext = orderContext;
		}
		public void AddAsync(Item entity)
		{
			_orderContext.Item.Add(entity);
		}

		public void DeleteAsync(int id)
		{
			var item = _orderContext.Item.Find(id);
			_orderContext.Item.Remove(item);
		}

		public async Task<IEnumerable<Item>> GetAllAsync()
		{
			return await _orderContext.Item.ToListAsync();
		}

		public async Task<Item> GetByIdAsync(int id)
		{
			return await _orderContext.Item.FirstAsync(x => x.Id == id);
		}

		
	}
}
