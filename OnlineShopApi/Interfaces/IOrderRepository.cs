using OnlineShopApi.Data.Entities;

namespace OnlineShopApi.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        void  AddAsync(Order entity);
       
        void DeleteAsync(int id);

       
    }
}
