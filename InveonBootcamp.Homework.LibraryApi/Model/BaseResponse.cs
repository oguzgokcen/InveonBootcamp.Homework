namespace InveonBootcamp.Homework.LibraryApi.Model
{
	public class BaseResponse<T>
	{
		public bool IsSuccess { get; set; } = true;
		public T? Data { get; set; }
		public List<string> Errors { get; set; }
	}
}
