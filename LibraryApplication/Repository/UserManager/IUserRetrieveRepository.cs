using LibraryApplication.Models.Identity;

namespace LibraryApplication.Repository.UserManager
{
	public interface IUserRetrieveRepository
	{
		Task<List<AppUser>> GetAppUsers();
		Task<List<AppRole>> GetUserRoles(Guid id);
	}
}
