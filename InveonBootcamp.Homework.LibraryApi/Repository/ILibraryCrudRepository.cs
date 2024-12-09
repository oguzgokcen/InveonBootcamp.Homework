using InveonBootcamp.Homework.LibraryApi.Model;

namespace InveonBootcamp.Homework.LibraryApi.Repository
{
	public interface ILibraryCrudRepository
	{
		public void Add(Book book);
		public bool Update(Book book);
		public bool Delete(int id);
	}
}
