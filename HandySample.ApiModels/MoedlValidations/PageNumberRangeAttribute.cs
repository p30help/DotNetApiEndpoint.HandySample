using System.ComponentModel.DataAnnotations;

namespace HandySample.ApiModels.MoedlValidations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Field, AllowMultiple = false)]
    public class PageNumberRangeAttribute : RangeAttribute
    {
        private const int MaxPageNumberValue = 100;

        public PageNumberRangeAttribute() : base(1, MaxPageNumberValue)
        {
            ErrorMessage = $"The acceptable value for 'PageNumber' is between 1 and {MaxPageNumberValue}'.";
        }
    }
}
