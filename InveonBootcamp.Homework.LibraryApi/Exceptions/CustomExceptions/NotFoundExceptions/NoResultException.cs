namespace InveonBootcamp.Homework.LibraryApi.Exceptions.CustomExceptions.NotFoundExceptions
{
	public class NoResultException : NotFoundException
	{
		public NoResultException(string searchTerm) :base($"No relevant data found for search term {searchTerm}"){ }
	}
}
