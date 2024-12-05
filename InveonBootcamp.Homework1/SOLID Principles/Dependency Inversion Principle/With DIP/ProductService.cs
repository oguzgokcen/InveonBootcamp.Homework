using InveonBootcamp.Homework.SOLID_Principles.Interface_Segretation.With_Interface_Segretation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Dependency_Inversion_Principle.With_DIP
{
	public class ProductService
	{
		private IFakeAdminSmsEmailRepository EmailRepository;
		private IFakeDataStore FakeDataStore;

		private ProductCreateUpdateRepository ProductCreateUpdateRepository;
		public ProductService(IFakeAdminSmsEmailRepository emailRepository, IFakeDataStore fakeDataStore )
		{
			EmailRepository = emailRepository;
			FakeDataStore = fakeDataStore;
		}
		public void ChangeShippingCost(Product product, double newShippingCost)
		{
			product.ShippingCost = newShippingCost;
			FakeDataStore.UpdateProduct(product);
			EmailRepository.AddAdminEmail(new AdminEmail { Body = "Shipping cost updated", Subject = "Product shipping cost changed" });
		}
	}
}
