using Ardalis.GuardClauses;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace IdentityManagerAPI.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Create a standard ProblemDetails response
            var problemDetails = new ProblemDetails();

            // Here we check the type of the exception and customize the response
            switch (exception)
            {
                case ValidationException validationException:
                    problemDetails.Title = "Validation Error";
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Detail = "Please refer to the errors property for details.";
                    var errors = validationException.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await httpContext.Response.WriteAsJsonAsync(new { problemDetails, errors }, cancellationToken);
                    return true; 

                case NotFoundException notFoundException:
                    problemDetails.Title = "Resource Not Found";
                    problemDetails.Status = StatusCodes.Status404NotFound;
                    problemDetails.Detail = notFoundException.Message;
                    break;

                default: 
                    problemDetails.Title = "Internal Server Error";
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    problemDetails.Detail = "An unexpected error occurred. Please try again later.";
                    break;
            }

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true; 
        }
    }
}
