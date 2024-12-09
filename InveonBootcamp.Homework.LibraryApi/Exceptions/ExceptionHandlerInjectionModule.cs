using InveonBootcamp.Homework.LibraryApi.Exceptions.ExceptionHandlers;
using InveonBootcamp.Homework.LibraryApi.Exceptions.ExceptionsHandlers;
using Microsoft.AspNetCore.Diagnostics;

namespace InveonBootcamp.Homework.LibraryApi.ExceptionHandler
{
	public static class ExceptionHandlerInjectionModule
	{
		public static IServiceCollection AddCustomExceptionHandler(this IServiceCollection services)
		{
			#region Exceptions
			services.AddExceptionHandler<NotFoundExceptionHandler>();
			services.AddExceptionHandler<GlobalExceptionHandler>();
			services.AddProblemDetails();

			#endregion
			return services;
		}

	}
}
