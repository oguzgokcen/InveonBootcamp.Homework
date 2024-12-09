using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.Asynchronous_Programming.Async_Methods.WithAsync
{

	public class SendingSmsAsync
	{

		public static void SendSms(List<string> phoneNumbers)
		{
			Stopwatch sw = Stopwatch.StartNew();
			Parallel.ForEach(phoneNumbers, number =>
			{
				RetrySmsIfException(() =>
				{
					SendToSmsService(number);
				}, 2);


			});
			sw.Stop();
			Console.WriteLine("async : " + sw.ElapsedMilliseconds);
		}

		private static void RetrySmsIfException(Action action, int maxRetry)
		{
			int retryCount = 0;
			try
			{
				action();
				return;
			}
			catch (Exception ex)
			{
				retryCount++;

				// exponential delay between retries
				Thread.Sleep((int)Math.Pow(2, retryCount) * 100);
			}
		}
		private static bool SendToSmsService(string phoneNumber)
		{
			// Assume sms service throws exception
			Random random = new Random();
			if (random.Next(0, 10) < 9)
			{
				return true;
			}
			else
			{
				throw new Exception("An error occured in sms service");
			}
		}
	}
}
