using HandySample.ApiModels.Requests;
using System.ComponentModel.DataAnnotations;

namespace HandySample.ApiModels.MoedlValidations
{
    public class AddressValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var address = value as AddressRequest;

            if(address == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(address.PostalCode))
            {
                ErrorMessage = $"Postal Code must be filled";
                return false;
            }

            if (string.IsNullOrEmpty(address.AddressLine) == false)
            {
                if(!string.IsNullOrEmpty(address.Pelaq) || !string.IsNullOrEmpty(address.StreetLine))

                ErrorMessage = $"Pelaq and StreetLine must be empty";
                return false;
            }

            if (string.IsNullOrEmpty(address.StreetLine) && string.IsNullOrEmpty(address.AddressLine))
            {
                ErrorMessage = $"Either StreetLine or AddressLine must be filled";
                return false;
            }

            return true;
        }
    }
}
