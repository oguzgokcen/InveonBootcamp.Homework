using LibraryApplication.Models.BookModel;
using LibraryApplication.Models.DTO.BookDto_s;
using LibraryApplication.Models.DTO.JTableDto;

namespace LibraryApplication.Service.BookServices
{
    public interface IBookService
    {
		Task<List<Book>> GetAllBooks(JTableParams jTableParams);
		Task<bool> AddBook(AddBookDto addBookDto);
		Task<bool> UpdateBook(UpdateBookDto updateBookDto);
		Task<bool> DeleteBook(int Id);
		Task<Book?> GetBookById(int Id);
	}
}
