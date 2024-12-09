using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.Homework.LibraryApi.Exceptions.ExceptionHandlers
{
	public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
		{
			logger.LogError(exception, "An unhandled exception occurred.");

			httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
			httpContext.Response.ContentType = "application/json";

			await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
			{
				Status = StatusCodes.Status500InternalServerError,
				Detail = exception.Message,
				Title = "Internal Server Error",
				Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
			});

			return true;
		}
	}

}
