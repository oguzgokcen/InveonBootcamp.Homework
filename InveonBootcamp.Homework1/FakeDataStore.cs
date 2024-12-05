using InveonBootcamp.Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework
{
	public class FakeDataStore : IFakeDataStore
	{
		private static List<Product> _products;

		public FakeDataStore()
		{
			_products = new List<Product>
			{
				new Product { Id = 1, Name = "Test Product 1" },
				new Product { Id = 2, Name = "Test Product 2" },
				new Product { Id = 3, Name = "Test Product 3" }
			};
		}

		public void AddProduct(Product product)
		{
			_products.Add(product);
		}

		// Remove a product by ID
		public void RemoveProduct(int id)
		{
			var product = _products.FirstOrDefault(x => x.Id == id);
			if (product != null)
			{
				_products.Remove(product);
			}
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _products;
		}

		public Product GetProductById(int id)
		{
			return _products.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Product> GetProductsByName(string name)
		{
			return _products.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
		}

		public void UpdateProduct(Product updatedProduct)
		{
			var existingProduct = _products.FirstOrDefault(x => x.Id == updatedProduct.Id);
			if (existingProduct != null)
			{
				existingProduct.Name = updatedProduct.Name;
				existingProduct.Price = updatedProduct.Price;
				existingProduct.ShippingCost = updatedProduct.ShippingCost;
			}
		}

		public bool ProductExists(int id)
		{
			return _products.Any(x => x.Id == id);
		}

		public int GetProductCount()
		{
			return _products.Count;
		}
	}
}
