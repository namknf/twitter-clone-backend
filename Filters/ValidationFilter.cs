namespace Twitter_backend.Filters
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Twitter_backend.Models;
    using Twitter_backend.Responses;

    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            /* before controller */

            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(error => error.Value.Errors.Count > 0)
                    .ToDictionary(keyValPair => keyValPair.Key, keyValPair => keyValPair.Value.Errors.Select(errMes => errMes.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel()
                        {
                            FieldName = error.Key,
                            FriendlyMessage = subError,
                        };

                        errorResponse.Errors.Add(errorModel);
                    }

                    context.Result = new BadRequestObjectResult(errorResponse);
                    return;
                }
            }

            await next();

            /* after controller */
        }
    }
}
