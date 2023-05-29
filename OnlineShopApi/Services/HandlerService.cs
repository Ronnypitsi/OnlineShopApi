using Microsoft.AspNetCore.Mvc;
using OnlineShopApi.Data;
using OnlineShopApi.Data.Entities;
using OnlineShopApi.Dtos;
using OnlineShopApi.Interfaces;

namespace OnlineShopApi.Services
{
	public class HandlerService: IHandlerService
	{
		private readonly IUnitOfWork _unitOfWork;
		public HandlerService(IUnitOfWork unitOfWork) 
		{
			_unitOfWork=unitOfWork;
		}
		public async Task<IEnumerable<Item>> GetAllItems()
		{
			return await _unitOfWork.ItemRepository.GetAllAsync();
		}
		public async Task<IEnumerable<Order>> GetAllOrders()
		{
			return await _unitOfWork.OrderRepository.GetAllAsync();
		}
		public async Task<IEnumerable<CartItemDto>> GetCartItems()
		{
			var result =await _unitOfWork.CartItemRepository.GetAllAsync();
			List<CartItemDto> cartItems = new List<CartItemDto>();
			foreach (var item in result)
			{
				CartItemDto cartItem = new CartItemDto();
				cartItem.Id = item.Id;
				cartItem.Quantity = item.Quantity;
				cartItem.ItemId = item.ItemId;

				var itemd = await _unitOfWork.ItemRepository.GetByIdAsync(item.ItemId);
				if (itemd != null)
				{
					ItemDto itemDto = new ItemDto();
					itemDto.Id = itemd.Id;
					itemDto.Name = itemd.Name;
					itemDto.Description = itemd.Description;
					itemDto.Image = itemd.Image;
					itemDto.Price = itemd.Price;
					cartItem.Item = itemDto;
					cartItem.Total = item.Quantity * itemd.Price;
					cartItems.Add(cartItem);
				}
			}
			return  cartItems;
		}
		public async Task<CartItem> RemoveItemFromCart(int id)
		{
			var cartItems = await _unitOfWork.CartItemRepository.GetByIdAsync(id);
			if (cartItems != null)
			{
				_unitOfWork.CartItemRepository.DeleteAsync(id);
				await _unitOfWork.SaveAsync();
				return cartItems;
			}

			return cartItems;
		}
		public async Task<CartItem> AddItemToCart(int itemId, int quantity)
		{
			CartItem cartItem = new CartItem();
			cartItem.Quantity = quantity;
			cartItem.ItemId = itemId;
			cartItem.Date = DateTime.Now;
			 _unitOfWork.CartItemRepository.AddAsync(cartItem);
			await _unitOfWork.SaveAsync();
			return cartItem;
		}
		public async Task<IEnumerable<Order>> PlaceOrder(List<CartItemDto> cartItems, decimal total)
		{
			Order order = new Order();
			order.TotalPrice = total;
			order.Date = DateTime.Now;

			_unitOfWork.OrderRepository.AddAsync(order);
			await _unitOfWork.SaveAsync();
			foreach (var item in cartItems)
			{
				OrderItem orderItem = new OrderItem();
				orderItem.ItemId = item.ItemId;
				orderItem.Quantity = item.Quantity;
				orderItem.Price = item.Item.Price;
				orderItem.Date = DateTime.Now;
				orderItem.OrderId = order.Id;
				_unitOfWork.OrderItemRepository.AddAsync(orderItem);
				await _unitOfWork.SaveAsync();
				
				_unitOfWork.CartItemRepository.DeleteAsync(item.Id);
				await _unitOfWork.SaveAsync();

			}
			
		
			return await _unitOfWork.OrderRepository.GetAllAsync();
		}

	}
}
