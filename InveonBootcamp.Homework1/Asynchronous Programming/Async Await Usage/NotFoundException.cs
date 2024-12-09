using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.Asynchronous_Programming.Async_Await_Usage
{
	public class UserNotFoundException : Exception
	{
		public UserNotFoundException(string? userId)
			: base(userId == null ? "User ID is null." : $"User '{userId}' not found.")
		{
		}
	}

	public class ProductNotFoundException : Exception
	{
		public ProductNotFoundException(string? productId)
			: base(productId == null ? "Product ID is null." : $"Product '{productId}' not found.")
		{
		}
	}
}
