using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
namespace DevFreela.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        //Executado  dps da requisicao
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new System.NotImplementedException();
        }

        //Executa antes de tudo
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                var messages = context.ModelState
                .SelectMany( ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
                
                context.Result = new BadRequestObjectResult(messages);
            }
        }
    }
}