using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Models.Identity
{
	public class AppRole:IdentityRole<Guid>
	{
		public virtual ICollection<AppUserRole> UserRoles { get; set; }
	}
}
