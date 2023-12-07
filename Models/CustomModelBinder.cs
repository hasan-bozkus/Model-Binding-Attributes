using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using Model_Binding_Attributes.Models;

namespace Model_Binding_Attributes.Models
{
    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var name = bindingContext.ActionContext.HttpContext.Request.Query["name"];

            var result = new CustomViewModel
            {
                NameSurname = name + " Bozkuş"
            };

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }

    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(CustomViewModel))
                return new CustomModelBinder();

            return null;
        }
    }
}
