using InveonBootcamp.Homework.LibraryApi.Exceptions.CustomExceptions.NotFoundExceptions;
using InveonBootcamp.Homework.LibraryApi.FakeDbContext;
using InveonBootcamp.Homework.LibraryApi.Model;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace InveonBootcamp.Homework.LibraryApi.Repository
{

	public class LibraryRetrieveRepository : ILibraryRetrieveRepository
	{
		private readonly IDistributedCache DistributedCache;
		private readonly ICacheRepository CacheRepository;
		public LibraryRetrieveRepository(IDistributedCache distributedCache, ICacheRepository cacheRepository)
		{
			DistributedCache = distributedCache;
			CacheRepository = cacheRepository;
		}
        public IEnumerable<Book> GetAllBooks(string keyword, int startIndex, int pageSize, out int totalCount)
		{
			IEnumerable<Book> data;
			if(string.IsNullOrEmpty(keyword) && startIndex + pageSize <= 10)
			{
				data = CacheRepository.GetAllBooks(startIndex, pageSize).Result;
				totalCount = data.Count();
				return data;
			}
			var query = LibraryDbContext.Books.Where(x => x.Title.Contains(keyword));
			totalCount = query.Count();
			data =  query.Skip(startIndex).Take(pageSize).ToList();
			return data;
		}

		public Book GetBook(int id)
		{
			var data = LibraryDbContext.Books.Where(x => x.Id == id).FirstOrDefault();
			if(data == null)
			{
				throw new BookNotFoundException(id);
			}
			return data;
		}

		public IEnumerable<Book> GetBooksByAuthor(string author, int startIndex, int pageSize, out int totalCount)
		{
			var query = LibraryDbContext.Books.Where(x => x.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
			totalCount = query.Count();
			if (totalCount == 0)
			{
				throw new NoResultException(author);
			}
			return query.Skip(startIndex).Take(pageSize).ToList();
		}
	}
}
