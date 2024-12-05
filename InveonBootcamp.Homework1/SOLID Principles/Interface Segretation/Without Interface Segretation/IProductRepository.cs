using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Interface_Segretation
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAllProducts();
		Product GetProductById(int id);
		IEnumerable<Product> GetProductsByName(string name);
		void RemoveProduct(int id);
		void AddProduct(Product product);
		void UpdateProduct(Product updatedProduct);

	}
}
