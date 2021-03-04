using System;

namespace Rectangle.Impl
{
	public sealed class Point : IEquatable<Point>
	{
		public int X { get; set; }
		public int Y { get; set; }

		public bool Equals(Point other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return X == other.X && Y == other.Y;
		}
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is Point other && Equals(other);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}
	}
}
