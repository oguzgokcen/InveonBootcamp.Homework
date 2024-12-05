using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Open_Closed_Principle
{
	public class SellerEmailServiceOCP
	{

		public SellerEmailServiceOCP() { }

		// Virtual Method
		public void NotifyAdminNewProductAdded(Product product)
		{
			Console.WriteLine(product.ProductAddedMessage());
		}
	}
}
