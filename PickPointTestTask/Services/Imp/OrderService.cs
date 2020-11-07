using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PickPointTestTask.Models;
using PickPointTestTask.Models.Entities;
using PickPointTestTask.Models.ViewModels;

namespace PickPointTestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<int> CreateOrder(OrderCreatingModel model)
        {
            var orderEntity = (OrderEntity) model;
            orderEntity.PostamatId = _context.Postamats.First(entity => entity.Number == model.PostamatNumber).Id;
            await _context.Orders.AddAsync(orderEntity);

            await _context.SaveChangesAsync();
            return orderEntity.Id;
        }

        public Task<List<OrderViewModel>> GetAllOrders() =>
            _context.Orders.Select(entity => (OrderViewModel) entity).ToListAsync();

        public async Task EditOrder(OrderEditingModel model)
        {
            var existing = await _context.Orders.FindAsync(model.Id);
            _context.Entry(existing).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
        }

        public async Task CancelOrder(int orderId)
        {
            var existing = await _context.Orders.FirstOrDefaultAsync(entity => entity.Id == orderId);
            existing.Status = OrderStatus.Canceled;
            await _context.SaveChangesAsync();
        }
    }
}