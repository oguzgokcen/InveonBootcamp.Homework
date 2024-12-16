using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryApplication.Repository.UserManager
{
	public class UserRetrieveRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager) : IUserRetrieveRepository
	{
		public async Task<List<AppUser>> GetAppUsers()
		{
			return await userManager.Users.Include(x => x.UserRoles).Include(x=>x.UserDetails).ToListAsync();
		}

		public async Task<AppUser?> Login(LoginDto loginDto)
		{
			var user = await userManager.FindByEmailAsync(loginDto.Email);
			if(user == null)
			{
				return null;
			}

			var passwordCheck = await userManager.CheckPasswordAsync(user, loginDto.Password);

			if (!passwordCheck)
			{
				throw new SystemException("Password is not match.");
			}

			return user;
		}
 	}
}
