using LibraryApplication.Models.BookModel;
using LibraryApplication.Models.DTO.JTableDto;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Repository.BookManager
{
    public class BookRepository(AppDbContext appDbContext) : IBookRepository
	{
		public async Task<List<Book>> GetAllBooks(JTableParams jTableParams)
		{
			return await appDbContext.Books.Skip(jTableParams.StartIndex).Take(jTableParams.PageSize).ToListAsync();
		}

		public async Task<Book> GetBookById(int Id)
		{
			return await appDbContext.Set<Book>().FindAsync(Id);
		}

		public async Task AddBook(Book book)
		{
			await appDbContext.Set<Book>().AddAsync(book);
		}

		public async Task UpdateBook(Book book)
		{
			await Task.Run(() =>appDbContext.Set<Book>().Update(book));
		}

		public async Task DeleteBook(Book book)
		{
			await Task.Run(() => appDbContext.Set<Book>().Remove(book));
		}

		public async Task<Book?> GetByIdAsync(int id)
		{
			return await appDbContext.Books.FindAsync(id);
		}
	}
}
