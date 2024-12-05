using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Interface_Segretation.With_Interface_Segretation
{
	public class ProductRetrieveRepository : IProductRetriever
	{
		private static List<Product> _products;
		public ProductRetrieveRepository(List<Product> products) 
		{
			_products = products;
		}
		public IEnumerable<Product> GetAllProducts()
		{
			return _products;
		}

		// Find a product by ID
		public Product GetProductById(int id)
		{
			return _products.FirstOrDefault(x => x.Id == id);
		}

		// Find products by name
		public IEnumerable<Product> GetProductsByName(string name)
		{
			return _products.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
		}
	}
}
