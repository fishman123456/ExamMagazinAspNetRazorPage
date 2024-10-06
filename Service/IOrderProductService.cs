using ExamMagazinAspNetRazorPage.Models;

namespace ExamMagazinAspNetRazorPage.Service

{
    public interface IOrderProductService
    {
        
        Task<OrderProduct?> Add(OrderProduct orderProduct);

        
        Task<OrderProduct?> GetById(int id);

        
        Task<List<OrderProduct>> ListAll();

       
        Task<OrderProduct?> RemoveById(int id);

        
        Task<OrderProduct?> UpdateById(int id, OrderProduct orderProduct);
    }
}
