using LibraryApplication.Models.BookModel;
using LibraryApplication.Models.DTO.JTableDto;

namespace LibraryApplication.Repository.BookManager
{
	public interface IBookRepository
	{
		Task<List<Book>> GetAllBooks(JTableParams jTableParams);
		Task<Book> GetBookById(int Id);
		Task AddBook(Book book);
		Task UpdateBook(Book book);
		Task DeleteBook(Book book);
		Task<Book?> GetByIdAsync(int id);
	}
}
