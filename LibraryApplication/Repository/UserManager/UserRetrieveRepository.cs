using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Repository.UserManager
{
	public class UserRetrieveRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager) : IUserRetrieveRepository
	{
		public async Task<List<AppUser>> GetAppUsers()
		{
			return await userManager.Users.Include(x => x.UserRoles).Include(x=>x.UserDetails).ToListAsync();
		}

		public async Task<AppUser?> GetUserById(Guid id)
		{
			return await userManager.FindByIdAsync(id.ToString());
		}

		public async Task<List<AppRole>> GetUserRoles(Guid id)
		{
			return await roleManager.Roles.Include(x => x.UserRoles).Where(x => x.UserRoles.Any(y => y.UserId == id)).ToListAsync();
		}
	}
}
