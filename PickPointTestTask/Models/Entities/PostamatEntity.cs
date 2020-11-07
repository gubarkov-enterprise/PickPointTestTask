using System.Collections.Generic;

namespace PickPointTestTask.Models.Entities
{
    public class PostamatEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public virtual List<OrderEntity> Orders { get; set; }
        public string Address { get; set; }
        public bool OnDuty { get; set; }
    }
}