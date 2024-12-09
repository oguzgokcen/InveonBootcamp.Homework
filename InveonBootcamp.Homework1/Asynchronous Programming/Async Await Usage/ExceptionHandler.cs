using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.Asynchronous_Programming.Async_Await_Usage
{
	public interface IExceptionHandler
	{
		void HandleException(Exception ex);
	}
	public class ExceptionHandler()
	{
		public static void HandleException(Exception ex)
		{
			if(ex is UserNotFoundException || ex is ProductNotFoundException)
			{
				Console.WriteLine("Logging critical exception : " +  ex.Message);
			}
			throw ex;
		}
	}
}
