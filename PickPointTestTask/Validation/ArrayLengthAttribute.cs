using System.ComponentModel.DataAnnotations;
using PickPointTestTask.Models.ViewModels;

namespace PickPointTestTask.Validation
{
    public class ArrayLengthAttribute : ValidationAttribute
    {
        private readonly int _maxLength;

        public ArrayLengthAttribute(int maxLength)
        {
            _maxLength = maxLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) =>
            ((OrderCreatingModel) validationContext.ObjectInstance).Products.Length > _maxLength
                ? new ValidationResult($"Products count should be less than {_maxLength}")
                : ValidationResult.Success;
    }
}