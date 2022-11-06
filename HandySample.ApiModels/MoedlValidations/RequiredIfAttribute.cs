using System.ComponentModel.DataAnnotations;
using System.Linq.Dynamic.Core;

namespace HandySample.ApiModels.MoedlValidations
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _condition;

        public RequiredIfAttribute(string condition)
        {
            _condition = condition;
        }

        private static Delegate CreateExpression(Type objectType, string expression)
        {
            var lambdaExpression =
                DynamicExpressionParser.ParseLambda(
                    objectType, typeof(bool), expression);
            var func = lambdaExpression.Compile();
            return func;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var conditionFunction = CreateExpression(validationContext.ObjectType, _condition);
            var conditionMet = (bool)conditionFunction.DynamicInvoke(validationContext.ObjectInstance);
            if (!conditionMet) return null;

            if (value != null && int.TryParse(value.ToString(), out var parsedValue))
            {
                return parsedValue == 0
                    ? new ValidationResult($"Field {validationContext.MemberName} is required")
                    : null;
            }

            return new ValidationResult($"Field {validationContext.MemberName} is required");
        }
    }
}
