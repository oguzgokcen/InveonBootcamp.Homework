using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.Asynchronous_Programming.Async_Methods
{
	public class PhoneNumberHelper
	{
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

		public static List<string> GenerateRandomPhoneNumbers(int count, int maxLength)
		{
			List<string> phoneNumbers = new List<string>();
			Random random = new Random();

			for (int i = 0; i < count; i++)
			{
				string number = GenerateRandomNumber(random, maxLength);
				phoneNumbers.Add(number);
			}

			return phoneNumbers;
		}

		private static string GenerateRandomNumber(Random random, int maxLength)
		{
			// Generate a random number with a length between 1 and maxLength
			int length = random.Next(1, maxLength + 1);
			char[] number = new char[length];

			for (int i = 0; i < length; i++)
			{
				// Random digit between '0' and '9'
				number[i] = (char)random.Next('0', '9' + 1);
			}

			return new string(number);
		}
	}
}
