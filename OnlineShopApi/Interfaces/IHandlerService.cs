using OnlineShopApi.Data.Entities;
using OnlineShopApi.Dtos;

namespace OnlineShopApi.Interfaces
{
	public interface IHandlerService
	{
		Task<IEnumerable<Item>> GetAllItems();
		Task<IEnumerable<Order>> GetAllOrders();
		Task<IEnumerable<Order>> PlaceOrder(List<CartItemDto> cartItems, decimal total);
		Task<CartItem> AddItemToCart(int itemId, int quantity);
		Task<CartItem> RemoveItemFromCart(int id);
		Task<IEnumerable<CartItemDto>> GetCartItems();
	}
}
