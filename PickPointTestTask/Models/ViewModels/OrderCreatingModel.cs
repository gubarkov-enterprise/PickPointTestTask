using System.ComponentModel.DataAnnotations;
using PickPointTestTask.Validation;

namespace PickPointTestTask.Models.ViewModels
{
    public class OrderCreatingModel
    {
        public OrderStatus Status { get; set; }
        [ArrayLength(10)] public string[] Products { get; set; }
        public decimal Price { get; set; }
        [Postamat] public string PostamatNumber { get; set; }
        [Required] [Phone] public string RecipientPhone { get; set; }
        public string RecipientName { get; set; }
    }
}