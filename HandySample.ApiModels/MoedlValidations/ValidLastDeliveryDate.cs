using HandySample.ApiModels.Requests;
using System.ComponentModel.DataAnnotations;

namespace HandySample.ApiModels.MoedlValidations
{
    public class ValidLastDeliveryDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (CreateCustomerRequest) validationContext.ObjectInstance;
            DateTime _lastDeliveryDate = Convert.ToDateTime(value);
            DateTime _dateJoin = Convert.ToDateTime(model.JoinDate);

            if (_dateJoin > _lastDeliveryDate)
            {
                return new ValidationResult
                    ("Last Delivery Date can not be less than Join date.");
            }
            else if (_lastDeliveryDate > DateTime.Now)
            {
                return new ValidationResult
                    ("Last Delivery Date can not be greater than current date.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
