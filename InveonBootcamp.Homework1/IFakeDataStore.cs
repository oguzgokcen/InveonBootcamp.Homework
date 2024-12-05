using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework
{
	public interface IFakeDataStore
	{
		void AddProduct(Product product);
		IEnumerable<Product> GetAllProducts();

		void UpdateProduct(Product product);
	}
}
