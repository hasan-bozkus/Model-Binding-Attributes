using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        public class QueryParameters
        {
            [BindNever]
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
