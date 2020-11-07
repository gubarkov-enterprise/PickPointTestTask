using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PickPointTestTask.Models.ViewModels;
using PickPointTestTask.Services;

namespace PickPointTestTask.Validation
{
    public class PostamatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IPostamatService) validationContext.GetService(typeof(IPostamatService));
            var model = (OrderCreatingModel) validationContext.ObjectInstance;
            var existingPostamat = service?.GetByNumber(model.PostamatNumber).Result;
            if (existingPostamat == null)
                return new ValidationResult("Postamat does not exist");
            return !existingPostamat.OnDuty
                ? new ValidationResult("Selected postamat is inactive")
                : ValidationResult.Success;
        }
    }
}