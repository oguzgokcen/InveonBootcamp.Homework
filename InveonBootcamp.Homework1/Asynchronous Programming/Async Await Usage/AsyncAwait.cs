using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.Asynchronous_Programming.Async_Await_Usage
{
	public class AsyncAwait
	{
		private static Dictionary<string, int> productStock = new Dictionary<string, int>
		{
			{ "ProductA", 5 },
			{ "ProductB", 0 }, // Out of stock
			{ "ProductC", 10 }
		};
		private static Dictionary<string, int> productStock2 = new Dictionary<string, int>
		{
			{ "ProductA", 5 },
			{ "ProductB", 10 },
			{ "ProductC", 10 },
			{ "ProductD", 10 }
		};

		private static Dictionary<string, int> userBalances = new Dictionary<string, int>
		{
			{ "User1", 50 },
			{ "User2", 30 },
			{ "User3", 70 }
		};

		public static async Task ProcessOrder(string userId, string product, int quantity, int productCost)
		{
			try
			{
				
				var productResult = CheckProductStore(product, quantity).ContinueWith(t=>
				{
					if (!t.Result)
					{
						throw new Exception($"No stock found for {product}");
					}
				});

				var isBalanceSufficient = CheckAvailableBalance(userId, productCost).ContinueWith(t =>
				{
					if (!t.Result)
					{
						throw new Exception($"Insufficient balance for user {userId}.");
					}
				});

				Task.WaitAll(isBalanceSufficient, productResult);
				IssueProduct(userId, product, quantity, productCost);

				bool isSmsSent = SendSmsOrderSuccess(userId, product, quantity);

				if (isSmsSent)
				{
					Console.WriteLine($"Order processed successfully for {userId}. SMS sent.");
				}
				else
				{
					Console.WriteLine($"Order processed successfully for {userId}, but SMS could not be sent.");
				}
			}
			catch (Exception ex)
			{
				ExceptionHandler.HandleException(ex);
			}
		}


		public static async Task<bool> CheckProductStore(string product, int quantity)
		{
			var result = false;
			await Task.Run(() =>
			{
				try
				{
					Thread.Sleep(2000); // Simulate a 2-second delay
					if (!productStock.ContainsKey(product) || productStock[product] < quantity)
					{
						result = CheckOtherProductStore(product, quantity).Result;
					}
					result = productStock[product] >= quantity;
				}
				catch (Exception ex)
				{
					ExceptionHandler.HandleException(ex);
				}
			});
			return result;
		}

		public static async Task<bool> CheckOtherProductStore(string product, int quantity)
		{
			var result = false;
			await Task.Run(() =>
			{
				Console.WriteLine("Checking other product store");
				try
				{
					Thread.Sleep(2000); // Simulate a 2-second delay
					if (!productStock2.ContainsKey(product))
					{
						throw new ProductNotFoundException(product);
					}
					result= productStock2[product] < quantity;
				}
				catch (Exception ex)
				{
					ExceptionHandler.HandleException(ex);
				}
			});
			return result;
		}

		public static async Task<bool> CheckAvailableBalance(string userId, int cost)
		{
			var result = false;
			await Task.Run(() =>
			{
				try
				{
					if (userId == null || !userBalances.ContainsKey(userId))
					{
						throw new UserNotFoundException(userId);
					}
					Thread.Sleep(1000); // Simulate a 1-second delay
					result= userBalances[userId] >= cost;
				}
				catch (Exception ex)
				{
					ExceptionHandler.HandleException(ex);
				}
			});
			return result;
		}
 
		public static bool SendSmsOrderSuccess(string userId, string product, int quantity)
		{
			Console.WriteLine($"Sending SMS to {userId} for {quantity} of {product}...");
			Thread.Sleep(500); // Simulate a delay for sending SMS
			return true; // Assume SMS sent successfully
		}

		private static void IssueProduct(string userId, string product, int quantity, int cost)
		{
			Console.WriteLine($"Issuing {quantity} of {product} to {userId}...");
			productStock[product] -= quantity;
			userBalances[userId] -= cost;
			Console.WriteLine($"Product issued. Remaining stock: {productStock[product]}, Remaining balance for {userId}: {userBalances[userId]}");
		}




	}
}
