using LibraryApplication.Helpers;
using LibraryApplication.Models.DTO.BookDto_s;
using LibraryApplication.Models.DTO.JTableDto;
using LibraryApplication.Models.Exceptions;
using LibraryApplication.Service.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
	public class BookController(IBookService bookService) : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public async Task<JsonResult> ListBooks(JTableParams jTableParams)
		{
			var books = await bookService.GetAllBooks(jTableParams);
			var data = books.Select(b => new
			{
				Id = b.Id,
				Title = b.Title,
				Author = b.Author,
				PublicationYear = b.PublicationYear,
				ISBN = b.ISBN,
				Genre = b.Genre,
				Publisher = b.Publisher,
				PageCount = b.PageCount,
				Language = b.Language,
				Summary = b.Summary,
				AvailableCopies = b.AvailableCopies
			}).ToList();

			return Json(data.ToJson());
		}

		public async Task<JsonResult> AddBook(AddBookDto addBookDto)
		{
			var result = await bookService.AddBook(addBookDto);

			if (result)
			{
				return Json(addBookDto.ToJson());
			}

			return Json(JsonExtensions.ToJsonError("Failed to add book."));
		}

		[HttpPost]
		public async Task<JsonResult> UpdateBook(UpdateBookDto updateBookDto)
		{
			var result = await bookService.UpdateBook(updateBookDto);

			if (result)
			{
				return Json(JsonExtensions.ToJsonOk());
			}

			return Json(JsonExtensions.ToJsonError("Failed to update book."));
		}

		[HttpPost]
		public async Task<JsonResult> DeleteBook(int Id)
		{
			var result = await bookService.DeleteBook(Id);

			if (result)
			{
				return Json(JsonExtensions.ToJsonOk());
			}

			return Json(JsonExtensions.ToJsonError("Failed to delete book."));
		}

		public async Task<IActionResult> Detail(int Id)
		{
			var book = await bookService.GetBookById(Id);
			if (book == null)
			{
				throw new ServiceException("Book not found");
			}

			return View(book);
		}

	}
}
