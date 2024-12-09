using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.Asynchronous_Programming.Task_Examples
{
	public class TaskExamples
	{
		private static string Url1 = "https://fake-json-api.mock.beeceptor.com/users";
		private static string Url2 = "https://httpbin.org/get";
		public static async Task WhenAllExample()
		{
			var httpClient = new HttpClient();

			List<Task<HttpResponseMessage>> httpResponses = new();

			httpResponses.Add(httpClient.GetAsync(Url1));
			httpResponses.Add(httpClient.GetAsync(Url2));

			var resultList = await Task.WhenAll(httpResponses);
            foreach (var item in resultList)
            {
				Console.WriteLine(item.RequestMessage!.RequestUri);
            }

        }

		public static async Task TaskWhenAnyExample()
		{
			Random random = new Random();
			var t1 = Task.Run(async () =>
			{
				Thread.Sleep(random.Next(0, 10)*1000);
				Console.WriteLine("Task 1 ended");
			});
			var t2 = Task.Run(async () =>
			{
				Thread.Sleep(random.Next(0, 10) * 1000);
				Console.WriteLine("Task 2 ended");
			});

			await Task.WhenAny(t1, t2);
		}

		public static async Task TaskContinueWith()
		{
			Random random = new Random();
			var t1 = Task.Run(async () =>
			{
				Thread.Sleep(random.Next(0, 10) * 1000);
				Console.WriteLine("Task 1 ended");
			}).ContinueWith(t2 =>
			{
				// end task2 after task 1
				Console.WriteLine("Task 2 ended");
			});

			await t1;
		}

	}
}
