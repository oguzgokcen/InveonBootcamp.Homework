// See https://aka.ms/new-console-template for more information
using InveonBootcamp.Homework.Asynchronous_Programming.Async_Await_Usage;
using InveonBootcamp.Homework.Asynchronous_Programming.Async_Methods;
using InveonBootcamp.Homework.Asynchronous_Programming.Async_Methods.WithAsync;
using InveonBootcamp.Homework.Asynchronous_Programming.Async_Methods.WithoutAsync;
using InveonBootcamp.Homework.Asynchronous_Programming.Task_Examples;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

#region Async Tests
/*
async Task testAsyncRuntimes()
{
	List<string> phoneNumbers = PhoneNumberHelper.GenerateRandomPhoneNumbers(500, 9);
	Stopwatch sw = Stopwatch.StartNew();
	var t1 = Task.Run(() => SendingSms.SendSms(phoneNumbers)).ContinueWith(x =>
	{
		sw.Stop();
		Console.WriteLine("Elapsed seconds" + sw.ElapsedMilliseconds);
	});

	var t2 = Task.Run(() => SendingSmsAsync.SendSms(phoneNumbers));
	
	Task.WaitAll(t1, t2);
}

await testAsyncRuntimes();

await TaskExamples.WhenAllExample();

await TaskExamples.TaskWhenAnyExample();
*/
#endregion

//await AsyncAwait.ProcessOrder("User5","Product4",1,20);