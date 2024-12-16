using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Exceptions;
using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryApplication.Repository.UserManager
{
	public class UserCudRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager,AppDbContext appDbContext) : IUserCudRepository
	{
		public async Task<IdentityResult> AddUser(AddUserDto addUserDto)
		{
			var user = new AppUser
			{
				Email = addUserDto.Email,
				UserName = addUserDto.Email,
				UserDetails = new UserDetails
				{
					FullName = addUserDto.FullName,
					CreatedOnUtc = DateTime.UtcNow
				}
			};
			var createUserResult =  await userManager.CreateAsync(user, addUserDto.Password);
			return createUserResult;
		}

		public async Task UpdateUser(UpdateUserDto updateUserDto)
		{
			var existingUser = await userManager.Users.Include(x=> x.UserDetails).FirstOrDefaultAsync(x => x.Id == updateUserDto.UserId);
			if (existingUser == null)
			{
				throw new ServiceException("User not found");
			}
			existingUser.Email = updateUserDto.Email;
			existingUser.UserName = updateUserDto.Email;
			if(existingUser.UserDetails == null)
			{
				existingUser.UserDetails = new UserDetails
				{
					FullName = updateUserDto.FullName
				};
			}
			else
			{
				existingUser.UserDetails.FullName = updateUserDto.FullName;
			}
			appDbContext.Users.Update(existingUser);
		}

		public async Task DeleteUser(Guid id)
		{
			var existingUser = await userManager.FindByIdAsync(id.ToString());
			if (existingUser == null)
			{
				throw new ServiceException("User not found");
			}
			appDbContext.Remove(existingUser);
		}
	}
}
