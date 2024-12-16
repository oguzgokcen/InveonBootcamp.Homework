using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Exceptions;
using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Repository.RoleManager
{
	public class RoleRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, AppDbContext appDbContext) : IRoleRepository
	{
		public async Task<IList<string>> GetUserRoles(Guid userId)
		{
			var user = await userManager.FindByIdAsync(userId.ToString());
			if (user == null)
			{
				throw new ServiceException("User not found");
			}
			return await userManager.GetRolesAsync(user);
		}
		public async Task<IdentityResult> AddRoleToUser(AddRoleDto addRoleDto)
		{
			var user = await userManager.FindByIdAsync(addRoleDto.UserId.ToString());
			if (user == null)
			{
				throw new ServiceException("User not found");
			}
			return await userManager.AddToRoleAsync(user, addRoleDto.RoleName);
		}
		public async Task<IdentityResult> DeleteUserRole(RemoveRoleFromUserDto removeRoleFromUserDto)
		{
			var user = await userManager.FindByIdAsync(removeRoleFromUserDto.UserId.ToString());
			if (user == null)
			{
				throw new ServiceException("User not found");
			}
			return await userManager.RemoveFromRoleAsync(user,removeRoleFromUserDto.RoleName);
		}

		public async Task<bool> CheckRoleExists(string roleName)
		{
			return await roleManager.RoleExistsAsync(roleName);
		}

		public async Task<List<AppRole>> GetRoles()
		{
			return await roleManager.Roles.ToListAsync();
		}

		public async Task<IdentityResult> AddRole(string roleName)
		{
			return await roleManager.CreateAsync(new AppRole()
			{
				Name=roleName
			});
		}

		public async Task UpdateRole(UpdateRoleDto updateRoleDto)
		{
			var role = await roleManager.FindByNameAsync(updateRoleDto.RoleName);
			if (role == null)
			{
				throw new ServiceException("Role not found");
			}
			role.Name = updateRoleDto.NewRoleName;
			await roleManager.UpdateAsync(role);
		}

		public async Task DeleteRole(string roleName)
		{
			var role = await roleManager.FindByNameAsync(roleName);
			if (role == null)
			{
				throw new ServiceException("Role not found");
			}
			appDbContext.Remove(role);
		}
	}
}
