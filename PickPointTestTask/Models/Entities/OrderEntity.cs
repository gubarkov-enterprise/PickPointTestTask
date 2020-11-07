using System.ComponentModel.DataAnnotations.Schema;
using PickPointTestTask.Models.ViewModels;

namespace PickPointTestTask.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Postamat))] public int PostamatId { get; set; }
        public OrderStatus Status { get; set; }
        public string[] Products { get; set; }

        public decimal Price { get; set; }

        public string PostamatNumber { get; set; }
        public string RecipientPhone { get; set; }
        public string RecipientName { get; set; }
        public virtual PostamatEntity Postamat { get; set; }

        public static explicit operator OrderEntity(OrderCreatingModel model) => new OrderEntity
        {
            Price = model.Price,
            Products = model.Products,
            RecipientName = model.RecipientName,
            PostamatNumber = model.PostamatNumber,
            RecipientPhone = model.RecipientPhone,
            Status = model.Status
        };
    }
}