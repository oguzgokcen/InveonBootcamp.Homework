using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Exceptions;
using LibraryApplication.Models.Identity;
using LibraryApplication.Repository;
using LibraryApplication.Repository.UserManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace LibraryApplication.Service.UserService
{
	public class UserService(IUserRetrieveRepository userRepository, IUserCudRepository userCudRepository, IUnitOfWork unitOfWork) : IUserService
	{
		public async Task<List<AppUser>> GetAppUsers()
		{
			var users = await userRepository.GetAppUsers();

			if (users == null)
			{
				throw new ServiceException("No users found");
			}

			return users;
		}

		public async Task<IdentityResult> CreateUser(AddUserDto user)
		{
			return await userCudRepository.AddUser(user);
		}

		public async Task<List<AppRole>> GetUserRoles(Guid id)
		{
			var roles = await userRepository.GetUserRoles(id);
			if (roles == null)
			{
				throw new ServiceException("No roles found");
			}
			return roles;
		}

		public async Task<bool> UpdateUser(UpdateUserDto updateUserDto)
		{
			await userCudRepository.UpdateUser(updateUserDto);
			await unitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteUser(Guid id)
		{
			await userCudRepository.DeleteUser(id);
			await unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
