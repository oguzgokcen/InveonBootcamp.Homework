using LibraryApplication.Repository.UserManager;
using LibraryApplication.Service.UserService;

namespace LibraryApplication.Repository.Extensions
{
	public static class ServiceDependencyInjectionModule
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			#region Repositories
			services.AddScoped<IUserRetrieveRepository, UserRetrieveRepository>();
			services.AddScoped<IUserCudRepository, UserCudRepository>();
			#endregion

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services;
		}
	}
}
