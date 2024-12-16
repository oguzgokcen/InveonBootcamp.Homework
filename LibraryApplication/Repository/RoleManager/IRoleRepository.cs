using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Repository.RoleManager
{
	public interface IRoleRepository
	{
		Task<IList<string>> GetUserRoles(Guid userId);
		Task<IdentityResult> AddRoleToUser(AddRoleDto addRoleDto);
		Task<IdentityResult> DeleteUserRole(RemoveRoleFromUserDto removeRoleFromUserDto);
		Task<bool> CheckRoleExists(string roleName);
		Task<List<AppRole>> GetRoles();
		Task<IdentityResult> AddRole(string roleName);
		Task UpdateRole(UpdateRoleDto updateRoleDto);
		Task DeleteRole(string roleName);
	}
}
