using InveonBootcamp.Homework.LibraryApi.FakeDbContext;
using InveonBootcamp.Homework.LibraryApi.JsonHelper;
using InveonBootcamp.Homework.LibraryApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace InveonBootcamp.Homework.LibraryApi.Repository
{
	public class CacheRepository : ICacheRepository
	{
		private IDistributedCache DistributedCache;
		public CacheRepository( IDistributedCache distributedCache)
		{
			DistributedCache = distributedCache;
		}
		public async Task<IEnumerable<Book>> GetAllBooks(int startIndex, int pageSize)
		{
			IEnumerable<Book> data;
			string key = "books-getAll";

			var cachedMember = await DistributedCache.GetStringAsync(key);
			if (string.IsNullOrEmpty(cachedMember))
			{
				data = LibraryDbContext.Books.Skip(startIndex).Take(pageSize).ToList();
				await DistributedCache.SetStringAsync(key, JsonSerializer.Serialize(data));
				return data;
			}
			data = JsonSerializer.Deserialize<IEnumerable<Book>>(cachedMember)!;
			return data;
		}
	}
}
