using InveonBootcamp.Homework.LibraryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace InveonBootcamp.Homework.LibraryApi.FakeDbContext
{
	public class LibraryDbContext
	{
		public static List<Book> Books { get; } = new List<Book>
		{
			new Book { Id = 1, Title = "C# Fundamentals", Author = "John Doe", IsAvailable = true },
			new Book { Id = 2, Title = "ASP.NET Core Advanced", Author = "Jane Smith", IsAvailable = false },
			new Book { Id = 3, Title = "Entity Framework Core", Author = "EF Team", IsAvailable = true },
			new Book { Id = 4, Title = "Design Patterns", Author = "Erich Gamma", IsAvailable = true },
			new Book { Id = 5, Title = "Clean Code", Author = "Robert C. Martin", IsAvailable = true },
			new Book { Id = 6, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", IsAvailable = false },
			new Book { Id = 7, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", IsAvailable = true },
			new Book { Id = 8, Title = "JavaScript: The Good Parts", Author = "Douglas Crockford", IsAvailable = true },
			new Book { Id = 9, Title = "You Don't Know JS: ES6 & Beyond", Author = "Kyle Simpson", IsAvailable = false },
			new Book { Id = 10, Title = "Python Crash Course", Author = "Eric Matthes", IsAvailable = true },
			new Book { Id = 11, Title = "Head First Java", Author = "Kathy Sierra", IsAvailable = false },
			new Book { Id = 12, Title = "Programming Rust", Author = "Jim Blandy", IsAvailable = true },
			new Book { Id = 13, Title = "Learning SQL", Author = "Alan Beaulieu", IsAvailable = true },
			new Book { Id = 14, Title = "Fluent Python", Author = "Luciano Ramalho", IsAvailable = true },
			new Book { Id = 15, Title = "Effective Java", Author = "Joshua Bloch", IsAvailable = false },
			new Book { Id = 16, Title = "The Clean Coder", Author = "Robert C. Martin", IsAvailable = true },
			new Book { Id = 17, Title = "Test-Driven Development by Example", Author = "Kent Beck", IsAvailable = true },
			new Book { Id = 18, Title = "Cracking the Coding Interview", Author = "Gayle Laakmann McDowell", IsAvailable = false },
			new Book { Id = 19, Title = "Algorithms", Author = "Robert Sedgewick", IsAvailable = true },
			new Book { Id = 20, Title = "Database System Concepts", Author = "Abraham Silberschatz", IsAvailable = true },

		};


	}
}
