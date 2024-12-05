using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InveonBootcamp.Homework.SOLID_Principles.Open_Closed_Principle.Without_OCP
{
	public class SellerEmailService
	{
		public SellerEmailService() { }
		public void NotifyAdminNewProductAdded(Product product)
		{
			if (product is Shoe)
			{
				Console.WriteLine($"New shoe product named {product.Name} added");
			}
			if (product is Cloth)
			{
				Console.WriteLine($"New Cloth product named {product.Name} added");
			}

			// goes on everytime new product type is defined
		}
	}
}
