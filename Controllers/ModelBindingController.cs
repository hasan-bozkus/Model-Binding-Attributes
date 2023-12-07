using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Model_Binding_Attributes.Models;

namespace Model_Binding_Attributes.Controllers
{
    public class ModelBindingController : Controller
    {
        public IActionResult BindRequiredExp(QueryParameters queryParameters)
        {
            if (ModelState.IsValid)
            {
                return Ok(new[]
                {
                 queryParameters.X, queryParameters.Y
             });
            }

            return BadRequest();
        }

        public IActionResult FromHeader([FromHeader] string accept)
        {
            return Ok(new[] { accept });
        }

        //public IActionResult Get([FromServices] INewsService _newsService, [FromQuery]int NewsId)
        //{
        //    return Ok(_newsService.Validate(NewsId));
        //}

        [HttpPost]
        public IActionResult FromBody([FromBody] FromBodyModel fromBodyModel)
        {
            return Ok(new[]
            {
                fromBodyModel.X, fromBodyModel.Y
            });
        }

        //Şimdi Custom olarak oluşturduğumuz Model Binding işlemini Action metodunda kullanalım.
        public string Get([ModelBinder(BinderType = typeof(CustomModelBinder))]CustomViewModel viewModel)
        {
            return viewModel.NameSurname;
        }


        public class QueryParameters
        {
            [BindNever]
            public int X { get; set; }
            public int Y { get; set; }
        }
        public class FromBodyModel
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public interface INewsService
        {
            bool Validate(int NewsId);
        }

        public class NewsService : INewsService
        {
            public bool Validate(int NewsId)
            {
                return true;
            }
        }
    }
}
