
using InveonBootcamp.Homework.LibraryApi.Exceptions.CustomExceptions.NotFoundExceptions;
using InveonBootcamp.Homework.LibraryApi.JsonHelper;
using InveonBootcamp.Homework.LibraryApi.Model;
using InveonBootcamp.Homework.LibraryApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InveonBootcamp.Homework.LibraryApi.Controllers
{
	[Route("api/[controller]/[action]")]
	public class LibraryController : Controller
	{
		private readonly ILibraryRetrieveRepository LibraryRetrieveRepository;
		private readonly ILibraryCrudRepository LibraryCrudRepository;
		public LibraryController(ILibraryRetrieveRepository libraryRetrieveRepository, ILibraryCrudRepository libraryCrudRepository)
		{
			LibraryRetrieveRepository = libraryRetrieveRepository;
			LibraryCrudRepository = libraryCrudRepository;
		}
		[HttpGet]
		public IActionResult Books(string keyword = "", int startIndex = 0, int pageSize = 10)
		{
			int total;
			IEnumerable<Book> data;
			data = LibraryRetrieveRepository.GetAllBooks(keyword, startIndex, pageSize, out total);
			return Json(new BaseResponse<object> { Data = data.ToJson(total) });
		}

		[HttpGet]
		public IActionResult GetBooksByAuthor(string authorName = "", int startIndex = 0, int pageSize = 10)
		{
			int total;
			var data = LibraryRetrieveRepository.GetBooksByAuthor(authorName, startIndex, pageSize, out total);
			return Json(new BaseResponse<object> { Data = data.ToJson(total) });
		}

		[HttpGet("{id}")]
		public IActionResult Book(int id)
		{
			var data = LibraryRetrieveRepository.GetBook(id);
			return Json(new BaseResponse<Book>()
			{
				Data = data
			});
		}

		[HttpPost]
		public IActionResult Book([FromBody] Book book)
		{
			LibraryCrudRepository.Add(book);

			return Json(new BaseResponse<bool>()
			{
				Data = true
			});
		}

		[HttpPut]
		public IActionResult UpdateBook([FromBody] Book book)
		{
			var result = LibraryCrudRepository.Update(book);
			return Json(new BaseResponse<bool>()
			{
				Data = result,
			});
		}

		[HttpDelete]
		public IActionResult DeleteBook(int id)
		{
			var result = LibraryCrudRepository.Delete(id);
			return Json(new BaseResponse<bool>()
			{
				Data = result,
			});
		}
	}
}
