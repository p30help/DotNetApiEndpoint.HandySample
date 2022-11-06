using HandySample.ApiModels.Requests;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HandySample.ApiModels.ModelBinders
{
    /// <summary>
    /// read more
    /// https://learn.microsoft.com/en-us/aspnet/core/mvc/advanced/custom-model-binding?view=aspnetcore-6.0
    /// </summary>
    public class OrderCodeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var value = bindingContext.ValueProvider.GetValue(bindingContext.FieldName).FirstValue;

            if (string.IsNullOrWhiteSpace(value))
            {
                return Task.CompletedTask;
            }

            var country = value.Substring(0, 2);
            var orderNum = value.Substring(2, value.Length - 2);

            if (int.TryParse(orderNum, out var _) == false)
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.FieldName, $"Please enter '{bindingContext.FieldName}' correct");
                return Task.CompletedTask;
            }

            var result = new OrderCodeRequest()
            {
                CountryCode = country,
                OrderNumber = orderNum
            };

            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }
    }
}
