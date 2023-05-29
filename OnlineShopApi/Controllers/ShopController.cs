using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controllers;
using WebApplication2;
using OnlineShopApi.Data.Entities;
using OnlineShopApi.Interfaces;
using OnlineShopApi.Dtos;

namespace OnlineShopApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ShopController : Controller
	{
		private readonly ILogger<Item> _logger;
		private readonly OrderContext _orderContext;
		private readonly IHandlerService _handlerService;

		public ShopController(ILogger<Item> logger, OrderContext OrderContext, IHandlerService handlerService)
		{
			_logger = logger;
			_orderContext = OrderContext;
			_handlerService = handlerService;
		}

		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result= await _handlerService.GetAllItems();
			return Ok(result);
		}
		[HttpGet("GetOrders")]
		public async Task<IActionResult> GetOrders()
		{
			var result = await _handlerService.GetAllOrders();
			return Ok(result);
		}
		[HttpPost("PlaceOrder")]
		public async Task<IActionResult> PlaceOrder(List<CartItemDto> cartItems,decimal total)
		{
			var order = await _handlerService.PlaceOrder(cartItems, total);
			return Ok(order);
		}
		[HttpPost("AddCart")]
		public async Task<IActionResult> AddItemToCart(int itemId,int quantity)
		{
			var cartItem= await _handlerService.AddItemToCart(itemId, quantity);
			return Ok(cartItem);
		}
		[HttpDelete("RemoveItemCart")]
		public async Task<IActionResult> RemoveItemFromCart(int id)
		{
			var cartItem = await _handlerService.RemoveItemFromCart(id);
			return Ok(cartItem);
		}
		[HttpGet("GetCart")]
		public async Task<IActionResult> GetCartItems()
		{
			var result = await _handlerService.GetCartItems();
			
			return Ok(result);
		}
	}
}
