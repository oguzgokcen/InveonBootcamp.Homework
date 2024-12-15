namespace LibraryApplication.Repository
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
	}
}
