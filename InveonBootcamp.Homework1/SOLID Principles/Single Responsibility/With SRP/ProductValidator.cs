using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Single_Responsibility.With_SRP
{
	public static class ProductValidator
	{

		public static bool IsValid(this Product product)
		{
			if (product == null)
				return false;

			if (product.Price <= 0)
				return false;

			if (product.TaxRate >= 100)
				return false;

			return true;
		}
	}
}
