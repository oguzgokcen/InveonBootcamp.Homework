using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Exceptions;
using LibraryApplication.Models.Identity;
using LibraryApplication.Repository;
using LibraryApplication.Repository.UserManager;
using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Service.UserServices
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

		public async Task<AppUser?> Login(LoginDto loginDto)
		{
			var user = await userRepository.Login(loginDto);
			return user;
		}

	}
}
