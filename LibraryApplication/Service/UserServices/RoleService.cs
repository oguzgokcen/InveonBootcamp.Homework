using LibraryApplication.Models.Identity;
using LibraryApplication.Repository.UserManager;
using LibraryApplication.Repository;
using Microsoft.AspNetCore.Identity;
using LibraryApplication.Models.Exceptions;
using LibraryApplication.Repository.RoleManager;
using LibraryApplication.Models.DTO.Identity;

namespace LibraryApplication.Service.UserServices
{
	public class RoleService(IRoleRepository roleRepository, IUserCudRepository userCudRepository, IUnitOfWork unitOfWork) : IRoleService
	{
		public async Task<IList<string>> GetUserRoles(Guid userId)
		{
			var roles = await roleRepository.GetUserRoles(userId);
			if (roles == null)
			{
				throw new ServiceException("Error getting roles.");
			}
			return roles;
		}
		public async Task<IdentityResult> AddRoleToUser(AddRoleDto addRoleDto)
		{
			return await roleRepository.AddRoleToUser(addRoleDto);
		}

		public async Task<IdentityResult> DeleteRoleFromUser(RemoveRoleFromUserDto removeRoleFromUserDto)
		{
			var ifExists = await roleRepository.CheckRoleExists(removeRoleFromUserDto.RoleName);
			if (!ifExists)
			{
				return IdentityResult.Failed(new IdentityError()
				{
					Description="Role Not Exists"
				});
			}
			return await roleRepository.DeleteUserRole(removeRoleFromUserDto);
		}

		public async Task<List<AppRole>> GetRoles()
		{
			return await roleRepository.GetRoles();
		}

		public async Task<IdentityResult> AddRole(string roleName)
		{
			return await roleRepository.AddRole(roleName);
		}

		public async Task UpdateRole(UpdateRoleDto updateRoleDto)
		{
			await roleRepository.UpdateRole(updateRoleDto);
			await unitOfWork.SaveChangesAsync();
		}

		public async Task DeleteRole(string roleName)
		{
			await roleRepository.DeleteRole(roleName);
			await unitOfWork.SaveChangesAsync();
		}
	}
}
