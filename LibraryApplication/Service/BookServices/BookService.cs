using LibraryApplication.Models.BookModel;
using LibraryApplication.Models.DTO.BookDto_s;
using LibraryApplication.Models.DTO.JTableDto;
using LibraryApplication.Repository;
using LibraryApplication.Repository.BookManager;

namespace LibraryApplication.Service.BookServices
{
    public class BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork) :IBookService
    {
		public async Task<List<Book>> GetAllBooks(JTableParams jTableParams)
		{
			return await bookRepository.GetAllBooks(jTableParams);
		}

		public async Task<bool> AddBook(AddBookDto addBookDto)
		{
			var book = new Book
			{
				Title = addBookDto.Title,
				Author = addBookDto.Author,
				PublicationYear = addBookDto.PublicationYear,
				ISBN = addBookDto.ISBN,
				Genre = addBookDto.Genre,
				Publisher = addBookDto.Publisher,
				PageCount = addBookDto.PageCount,
				Language = addBookDto.Language,
				Summary = addBookDto.Summary,
				AvailableCopies = addBookDto.AvailableCopies
			};

			await bookRepository.AddBook(book);
			await unitOfWork.SaveChangesAsync();

			return true;
		}

		public async Task<bool> UpdateBook(UpdateBookDto updateBookDto)
		{
			var book = await bookRepository.GetBookById(updateBookDto.Id);
			if (book == null)
			{
				return false;
			}

			book.Title = updateBookDto.Title;
			book.Author = updateBookDto.Author;
			book.PublicationYear = updateBookDto.PublicationYear;
			book.ISBN = updateBookDto.ISBN;
			book.Genre = updateBookDto.Genre;
			book.Publisher = updateBookDto.Publisher;
			book.PageCount = updateBookDto.PageCount;
			book.Language = updateBookDto.Language;
			book.Summary = updateBookDto.Summary;
			book.AvailableCopies = updateBookDto.AvailableCopies;

			await bookRepository.UpdateBook(book);
			await unitOfWork.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteBook(int Id)
		{
			var book = await bookRepository.GetBookById(Id);
			if (book == null)
			{
				return false;
			}

			await bookRepository.DeleteBook(book);
			await unitOfWork.SaveChangesAsync();

			return true;
		}

		public async Task<Book?> GetBookById(int Id)
		{
			return await bookRepository.GetByIdAsync(Id);
		}
	}
}
