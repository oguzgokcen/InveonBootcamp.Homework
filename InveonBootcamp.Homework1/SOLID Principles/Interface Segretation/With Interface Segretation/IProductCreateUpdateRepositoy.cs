using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Interface_Segretation
{
	public interface IProductCreateUpdateRepository
	{
		void AddProduct(Product product);
		void UpdateProduct(Product updatedProduct);
	}
}
