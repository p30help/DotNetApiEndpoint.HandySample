using System.ComponentModel.DataAnnotations;

namespace HandySample.ApiModels.MoedlValidations
{
    public class NationalCodeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var code = value.ToString();
            if (string.IsNullOrEmpty(code))
            {
                return true;
            }
            else if (code.Length == 10 && long.TryParse(code, out var _) == true)
            {
                return true;
            }

            ErrorMessage = "National Code is not correct";
            return false;
        }
    }
}
