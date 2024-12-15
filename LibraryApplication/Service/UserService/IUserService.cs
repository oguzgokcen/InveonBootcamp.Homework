using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Service.UserService
{
	public interface IUserService
	{
		Task<List<AppUser>> GetAppUsers();
		Task<IdentityResult> CreateUser(AddUserDto user);
		Task<List<AppRole>> GetUserRoles(Guid id);
		Task<bool> UpdateUser(UpdateUserDto updateUserDto);
		Task<bool> DeleteUser(Guid id);
	}
}
