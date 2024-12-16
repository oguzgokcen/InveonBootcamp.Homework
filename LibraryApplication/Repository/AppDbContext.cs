using LibraryApplication.Models.BookModel;
using LibraryApplication.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LibraryApplication.Repository
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, AppRole, Guid>(options)
	{
		public DbSet<Book> Books { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<AppUser>(b =>
			{
				b.HasMany(e => e.UserRoles)
				   .WithOne(e => e.User)
				   .HasForeignKey(ur => ur.UserId)
				   .IsRequired();
			});

			builder.Entity<AppRole>(b =>
			{
				b.HasMany(e => e.UserRoles)
					.WithOne(e => e.Role)
					.HasForeignKey(ur => ur.RoleId)
					.IsRequired();
			});

			builder.Entity<UserDetails>().HasKey(x => x.UserID);

			builder.Entity<UserDetails>().HasOne(x => x.AppUser).WithOne(x => x.UserDetails).HasForeignKey<UserDetails>(x => x.UserID);

		}
	}
}
