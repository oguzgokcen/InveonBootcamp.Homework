using InveonBootcamp.Homework.SOLID_Principles.Single_Responsibility.With_SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Single_Responsibility.With_SRP
{
	public class ProductServiceSRP
	{
		private IFakeDataStore DataRepository;
		private IProductNotifier ProductNotifier;

		private ProductServiceSRP(IFakeDataStore dataRepository, IProductNotifier productNotifier)
		{
			DataRepository = dataRepository;
			ProductNotifier = productNotifier;

		}
		public void AddProduct(Product product)
		{
			try
			{
				if (product.IsValid())
				{
					DataRepository.AddProduct(product);

					ProductNotifier.NotifyAdminNewProductAdded(product);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
