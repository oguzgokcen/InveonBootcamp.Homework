﻿using Microsoft.AspNetCore.Identity;

namespace LibraryApplication.Models.Identity
{
	public class AppUser : IdentityUser<Guid>
	{
		public ICollection<AppUserRole> UserRoles { get; set; }

		public UserDetails? UserDetails { get; set; }
	}
}
