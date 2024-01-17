using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace webapi.Filter;
public class ExceptionFilter : ExceptionFilterAttribute{
    public override void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        context.Result = new  OkObjectResult(new { errorMessage= ex.Message});
           
    }
}
