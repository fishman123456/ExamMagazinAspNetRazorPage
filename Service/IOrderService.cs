using ExamMagazinAspNetRazorPage.Models;

namespace ExamMagazinAspNetRazorPage.Service

{
    public interface IOrderService
    {
       
        Task<Order?> Add(Order order);

        
        Task<List<Order>> AddRange(List<Order> orders);

       
        Task<Order?> GetById(int id);

       
        Task<List<Order>> ListAll();

        
        Task<Order?> RemoveById(int id);

       
        Task<Order?> UpdateById(int id, Order order);
    }
}
