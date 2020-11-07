using System;
using PickPointTestTask.Models.Entities;

namespace PickPointTestTask.Models.ViewModels
{
    public class PostamatViewModel
    {
        public string Address { get; set; }
        public bool OnDuty { get; set; }
        public string Number { get; set; }

        public static implicit operator PostamatViewModel(PostamatEntity entity)
            => new PostamatViewModel
            {
                Address = entity.Address,
                OnDuty = entity.OnDuty,
                Number = entity.Number
            };
    }
}