namespace InveonBootcamp.Homework.LibraryApi.JsonHelper
{
	public static class JsonHelper
	{
		public static object ToJson<T>(this IEnumerable<T> data, int totalRecordCount)
		{
			return new {Records = data, TotalRecordCount = totalRecordCount };
		}

		public static object ToJsonResponse(this object data)
		{
			return new { Result = "OK", Record = data };
		}


	}
}
