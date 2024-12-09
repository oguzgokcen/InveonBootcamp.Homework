namespace InveonBootcamp.Homework.LibraryApi.Exceptions.CustomExceptions.NotFoundExceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(): base("Not Found") { }
		public NotFoundException(string message): base(message) { }
	}
}
