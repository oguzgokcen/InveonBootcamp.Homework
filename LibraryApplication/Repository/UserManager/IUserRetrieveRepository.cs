using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Identity;

namespace LibraryApplication.Repository.UserManager
{
	public interface IUserRetrieveRepository
	{
		Task<List<AppUser>> GetAppUsers();

		Task<AppUser> Login(LoginDto loginDto);
	}
}
