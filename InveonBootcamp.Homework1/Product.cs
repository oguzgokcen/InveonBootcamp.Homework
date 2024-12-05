using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int TaxRate { get; set; }
		public double Price { get; set; }
		public long SellerId { get; set; }
		public double ShippingCost { get; set; } = 0;

		public virtual string ProductAddedMessage()
		{
			return $"New product named {Name} added";
		}
	}
}
