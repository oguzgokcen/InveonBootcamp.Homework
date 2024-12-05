using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Interface_Segretation.With_Interface_Segretation
{
	public class ProductRemover : IProductRemover
	{
		private static List<Product> _products;
		public ProductRemover(List<Product> products)
		{
			_products = products;
		}

		public void RemoveProduct(int id)
		{
			var product = _products.FirstOrDefault(x => x.Id == id);
			if (product != null)
			{
				_products.Remove(product);
			}
		}
	}
}
