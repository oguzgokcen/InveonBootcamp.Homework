using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Interface_Segretation.With_Interface_Segretation
{
	public class ProductCreateUpdateRepository : IProductCreateUpdateRepository
	{
		private static List<Product> _products;
		public ProductCreateUpdateRepository(List<Product> products)
		{
			_products = products;
		}

		public void AddProduct(Product product)
		{
			_products.Add(product);
		}

		public void UpdateProduct(Product updatedProduct)
		{
			var existingProduct = _products.FirstOrDefault(x => x.Id == updatedProduct.Id);
			if (existingProduct != null)
			{
				existingProduct.Name = updatedProduct.Name;
				existingProduct.Price = updatedProduct.Price;
			}
		}


	}
}
