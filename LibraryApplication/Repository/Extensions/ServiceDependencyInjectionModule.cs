using LibraryApplication.Repository.RoleManager;
using LibraryApplication.Repository.UserManager;
using LibraryApplication.Service.UserServices;

namespace LibraryApplication.Repository.Extensions
{
	public static class ServiceDependencyInjectionModule
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			#region Repositories
			services.AddScoped<IUserRetrieveRepository, UserRetrieveRepository>();
			services.AddScoped<IUserCudRepository, UserCudRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			#endregion

			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services;
		}
	}
}
