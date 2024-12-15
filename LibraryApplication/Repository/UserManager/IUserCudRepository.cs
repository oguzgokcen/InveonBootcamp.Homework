using LibraryApplication.Models.DTO.Identity;
using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Repository.UserManager
{
	public interface IUserCudRepository
	{
		Task<IdentityResult> AddUser(AddUserDto addUserDto);
		Task UpdateUser(UpdateUserDto updateUserDto);
		Task DeleteUser(Guid id);
	}
}
