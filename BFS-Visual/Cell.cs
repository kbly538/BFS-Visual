using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bfsvisual
{
	public class Cell
	{

		public (int, int) prev { get; set; }
		public int x, y;

		public Cell(int x, int y)
		{

			prev = (-1, -1);
			this.x = x;
			this.y = y;
		}

		public override string ToString()
		{
			return String.Format("({0},{1})", x, y);
		}

		public bool IsSamePos(Cell other)
		{
			return this.x == other.x && this.y == other.y;
		}

		public override bool Equals(object? obj)
		{
			return this.GetHashCode() == obj?.GetHashCode();
		}

		public override int GetHashCode()
		{

			int hash = 17;

			hash = hash * 23 + this.x.GetHashCode() ^ this.y.GetHashCode() * this.y.GetHashCode();


			return hash;
		}
	}
}
