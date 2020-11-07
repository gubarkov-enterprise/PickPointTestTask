using PickPointTestTask.Models.Entities;

namespace PickPointTestTask.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string[] Products { get; set; }
        public decimal Price { get; set; }
        public string PostamatNumber { get; set; }
        public string RecipientPhone { get; set; }
        public string RecipientName { get; set; }

        public static implicit operator OrderViewModel(OrderEntity entity) =>
            new OrderViewModel
            {
                PostamatNumber = entity.PostamatNumber,
                Products = entity.Products,
                Status = entity.Status,
                Price = entity.Price,
                RecipientPhone = entity.RecipientPhone,
                RecipientName = entity.RecipientName,
                Id = entity.Id
            };
    }
}