using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Interface_Segretation.With_Interface_Segretation
{
	public interface IProductRetriever
	{
		IEnumerable<Product> GetAllProducts();
		Product GetProductById(int id);
		IEnumerable<Product> GetProductsByName(string name);
	}
}
