using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Single_Responsibility.WithoutSpr
{
	public class ProductService
	{
		private IFakeDataStore DataRepository;
		private IFakeAdminSmsEmailRepository AdminSmsEmailRepository;

		private ProductService(IFakeDataStore dataRepository, IFakeAdminSmsEmailRepository fakeAdminSmsEmailRepository)
		{
			DataRepository = new FakeDataStore();
			AdminSmsEmailRepository = new FakeAdminSmsEmailRepository();
		}
		public void AddProduct(Product product)
		{
			try
			{
				if (product.Price <= 0)
				{
					throw new Exception("Invalid product. Price cannot be smaller than or equal 0");
				}

				if (product.TaxRate > 100)
				{
					throw new Exception("Invalid tax rate. Price cannot be smaller than or equal 0");
				}

				DataRepository.AddProduct(product);

				AdminSmsEmailRepository.NotifyAdminNewProductAdded(product);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
