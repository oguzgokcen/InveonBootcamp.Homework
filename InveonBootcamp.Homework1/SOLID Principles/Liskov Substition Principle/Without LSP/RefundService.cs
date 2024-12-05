using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Liskov_Substition_Principle.Without_LSP
{
	public abstract class Cloth : Product
	{
		public int Size { get; set; }

		public abstract double RefundPrice();
	}
	public class TShirt : Cloth, IsRefundable
	{
		public override double RefundPrice()
		{
			return Price - ShippingCost;
		}
	}

	public class Underwear : Cloth
	{
		public string Color { get; set; }

		public override double RefundPrice()
		{
			throw new Exception("This Item is not refundable");
		}
	}

	public class RefundService
	{
		public void RefundCloth(Cloth cloth)
		{
			Console.WriteLine("Refunding : " + cloth.RefundPrice());
		}
	}
}
