namespace InveonBootcamp.Homework.LibraryApi.Exceptions.CustomExceptions.NotFoundExceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"Book with Id: {id} is not found.")
        { }
    }
}
