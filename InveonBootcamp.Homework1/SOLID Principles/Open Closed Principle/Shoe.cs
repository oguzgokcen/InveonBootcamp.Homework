using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Open_Closed_Principle
{
	public class Shoe : Product
	{
		public int ShoeSize { get; set; }

		public override string ProductAddedMessage()
		{
			return $"New shoe product named {Name} added";
		}
	}
}
