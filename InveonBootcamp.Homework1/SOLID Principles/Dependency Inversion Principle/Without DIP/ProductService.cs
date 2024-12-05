using InveonBootcamp.Homework.SOLID_Principles.Interface_Segretation.With_Interface_Segretation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Dependency_Inversion_Principle
{
	public class ProductService
	{
		private FakeAdminSmsEmailRepository EmailRepository;
		private FakeDataStore FakeDataStore;

	private ProductCreateUpdateRepository ProductCreateUpdateRepository;
		public ProductService() 
		{
			EmailRepository = new FakeAdminSmsEmailRepository();
			FakeDataStore = new FakeDataStore();
		}
		public void ChangeShippingCost(Product product, double newShippingCost)
		{
			product.ShippingCost = newShippingCost;
			FakeDataStore.UpdateProduct(product);
			EmailRepository.AddAdminEmail(new AdminEmail { Body = "Shipping cost updated", Subject = "Product shipping cost changed" });
		}
	}

}
