using InveonBootcamp.Homework.LibraryApi.Model;

namespace InveonBootcamp.Homework.LibraryApi.Repository
{
	public interface ILibraryRetrieveRepository
	{
		Book GetBook(int Id);
		IEnumerable<Book> GetAllBooks(string keyword, int startIndex, int pageSize, out int totalCount);

		IEnumerable<Book> GetBooksByAuthor(string Author, int startIndex, int pageSize, out int totalCount);
	}
}
