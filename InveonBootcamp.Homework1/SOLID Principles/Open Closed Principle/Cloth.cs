using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InveonBootcamp.Homework.SOLID_Principles.Open_Closed_Principle
{
	public class Cloth : Product
	{
		public int ClothSize { get; set; }
		public override string ProductAddedMessage()
		{
			return $"New Cloth product named {Name} added";
		}
	}


}
