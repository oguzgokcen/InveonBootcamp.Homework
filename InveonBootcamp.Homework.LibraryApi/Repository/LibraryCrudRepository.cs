using InveonBootcamp.Homework.LibraryApi.Exceptions.CustomExceptions.NotFoundExceptions;
using InveonBootcamp.Homework.LibraryApi.FakeDbContext;
using InveonBootcamp.Homework.LibraryApi.Model;

namespace InveonBootcamp.Homework.LibraryApi.Repository
{
	public class LibraryCrudRepository : ILibraryCrudRepository
	{
		public void Add(Book book)
		{
			LibraryDbContext.Books.Add(book);
		}

		public bool Delete(int id)
		{
			var bookToRemove = LibraryDbContext.Books.FirstOrDefault(b => b.Id == id);
			if (bookToRemove == null)
				throw new BookNotFoundException(id);

			return LibraryDbContext.Books.Remove(bookToRemove);
		}

		public bool Update(Book book)
		{
			var existingBookId = LibraryDbContext.Books.FindIndex(b => b.Id == book.Id);
			var existingBook = LibraryDbContext.Books.Find(b => b.Id == book.Id);
			if (existingBook == null)
				throw new BookNotFoundException(book.Id);

			existingBook.Title = book.Title;
			existingBook.Author = book.Author;
			existingBook.IsAvailable = book.IsAvailable;

			LibraryDbContext.Books[existingBookId] = existingBook;

			return true;
		}
	}
}
