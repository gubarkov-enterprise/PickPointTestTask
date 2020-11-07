using System.Collections.Generic;
using System.Threading.Tasks;
using PickPointTestTask.Models;
using PickPointTestTask.Models.ViewModels;

namespace PickPointTestTask.Services
{
    public interface IOrderService
    {
        Task<int> CreateOrder(OrderCreatingModel model);
        Task<List<OrderViewModel>> GetAllOrders();
        Task EditOrder(OrderEditingModel model);
        Task CancelOrder(int orderId);
    }
}