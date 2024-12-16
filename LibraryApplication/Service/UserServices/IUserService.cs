using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Service.UserServices
{
	public interface IUserService
	{
		Task<List<AppUser>> GetAppUsers();
		Task<IdentityResult> CreateUser(AddUserDto user);
		Task<bool> UpdateUser(UpdateUserDto updateUserDto);
		Task<bool> DeleteUser(Guid id);
		Task<AppUser> Login(LoginDto loginDto);
	}
}
