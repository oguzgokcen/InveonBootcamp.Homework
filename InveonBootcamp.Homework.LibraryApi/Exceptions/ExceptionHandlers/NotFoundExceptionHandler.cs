using InveonBootcamp.Homework.LibraryApi.Exceptions.CustomExceptions.NotFoundExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.Homework.LibraryApi.Exceptions.ExceptionsHandlers
{
	public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
		{
			if(exception is not NotFoundException)
			{
				return false;
			}
			logger.LogError(exception, "A not found exception occured");

			httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
			httpContext.Response.ContentType = "application/json";
			await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
			{
				Status = StatusCodes.Status400BadRequest,
				Detail = exception.Message,
				Title = "Object not found",
				Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
			});

			return true;
		}
	}
}
