using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Single_Responsibility.With_SRP
{

	public interface IProductNotifier
	{
		void NotifyAdminNewProductAdded(Product product);
	}

	public class ProductNotifier:IProductNotifier
	{
		private IFakeAdminSmsEmailRepository AdminSmsEmailRepository;
		public ProductNotifier(IFakeAdminSmsEmailRepository fakeAdminSmsEmailRepository)
		{
			AdminSmsEmailRepository = new FakeAdminSmsEmailRepository();
		}
		public void NotifyAdminNewProductAdded(Product product)
		{
			AdminSmsEmailRepository.NotifyAdminNewProductAdded(product);
		}
	}
}
