using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Service.UserServices
{
	public interface IRoleService
	{
		Task<IList<string>> GetUserRoles(Guid id);
		Task<IdentityResult> AddRoleToUser(AddRoleDto addRoleDto);
		Task<IdentityResult> DeleteRoleFromUser(RemoveRoleFromUserDto removeRoleFromUserDto);
		Task<List<AppRole>> GetRoles();
		Task<IdentityResult> AddRole(string roleName);
		Task UpdateRole(UpdateRoleDto updateRoleDto);
		Task DeleteRole(string roleName);

	}
}
