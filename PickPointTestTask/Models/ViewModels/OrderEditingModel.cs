namespace PickPointTestTask.Models.ViewModels
{
    public class OrderEditingModel
    {
        public int Id { get; set; }
        public string[] Products { get; set; }
        public decimal Price { get; set; }
        public string RecipientPhone { get; set; }
        public string RecipientName { get; set; }
    }
}