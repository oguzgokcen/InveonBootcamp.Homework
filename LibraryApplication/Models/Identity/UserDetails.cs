namespace LibraryApplication.Models.Identity
{
	public class UserDetails
	{
		public Guid UserID { get; set; }
		public DateTime CreatedOnUtc { get; set; }

		public DateTime? LastSeenOnUtc { get; set; }

		public string FullName { get; set; }

		public AppUser AppUser { get; set; } = default!;
	}
}
