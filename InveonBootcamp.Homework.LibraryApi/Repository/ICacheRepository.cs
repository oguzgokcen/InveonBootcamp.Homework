using InveonBootcamp.Homework.LibraryApi.Model;

namespace InveonBootcamp.Homework.LibraryApi.Repository
{
	public interface ICacheRepository
	{
		public Task<IEnumerable<Book>> GetAllBooks(int startIndex, int pageSize);
	}
}
