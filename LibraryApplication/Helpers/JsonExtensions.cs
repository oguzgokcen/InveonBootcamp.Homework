namespace LibraryApplication.Helpers
{
	public static class JsonExtensions
	{
		public static object ToJson<T>(this List<T> data)
		{
			return new { Result = "OK", Records = data, TotalRecordCount = data.Count };
		}

		public static object ToJson<T>(this IEnumerable<T> data)
		{
			return new { Result = "OK", Records = data.ToList(), TotalRecordCount = data.Count() };
		}

		public static object ToJsonOk()
		{
			return new { Result = "OK" };
		}

		public static object ToJsonError(string message)
		{
			return new { Result = "ERROR", Message = "'" + message + "'" };
		}
	}
}
