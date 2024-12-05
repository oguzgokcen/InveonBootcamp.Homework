using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.Homework.SOLID_Principles.Liskov_Substition_Principle
{
	public interface IsRefundable
	{
		double RefundPrice();
	}
	public abstract class Cloth : Product
	{
		public int Size { get; set; }
	}
	public class TShirt : Cloth, IsRefundable
	{
		public double RefundPrice()
		{
			return Price - ShippingCost;
		}
	}

	public class Underwear : Cloth
	{
		public string Color { get; set; }
	}

	public class RefundService
	{
		public void RefundCloth(Cloth cloth)
		{
			if (cloth is IsRefundable refundable)
			{
				Console.WriteLine("Refunding : " + refundable.RefundPrice());
			}
			else
			{
				Console.WriteLine("This cloth is inrefundable");
			}
		}
	}
}
