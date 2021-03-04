using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
	public static class Service
	{
		public static Rectangle FindRectangle(List<Point> points)
		{
			if (points.Any(_ => _ is null))
			{
				throw new ArgumentNullException();
			}
			if (points.Count < 2)
			{
				throw new ArgumentException("Less than 2 points!");
			}
			if ((from point in points
				from check in points
				where point != check
				where
					point.X == check.X && point.Y == check.Y
				select point).Any())
			{
				throw new ArgumentException("There can't be 2 points with identical X and Y");
			}
			var maxX = points.Select(_ => _.X).Max();
			var minX = points.Select(_ => _.X).Min();
			var maxY = points.Select(_ => _.Y).Max();
			var minY = points.Select(_ => _.Y).Min();
			if (points.Count(_ => _.X == maxX) == 1)
			{
				var height = maxY - minY > 1 ? maxY - minY : 1;
				return minX != maxX - 1 ? new Rectangle() {X = minX, Y = minY, Height = height, Width = maxX - minX - 1}
					: new Rectangle() {X = minX - 1, Y = minY, Height = height, Width = 1};
			}
			if (points.Count(_ => _.X == minX) == 1)
			{
				var height = maxY - minY > 1 ? maxY - minY : 1;
				return maxX != minX + 1
					? new Rectangle() {X = minX + 1, Y = minY, Height = height, Width = maxX - minX - 1}
					: new Rectangle() {X = maxX, Y = minY, Height = height, Width = 1};
			}
			if (points.Count(_ => _.Y == maxY) == 1)
			{
				var width = maxX - minX > 1 ? maxX - minX : 1;
				return minY != maxY - 1 ? new Rectangle() {X = minX, Y = minY, Height = maxY - minY - 1, Width = width}
					: new Rectangle() {X = minX, Y = minY - 1, Height = 1, Width = width};
			}
			if (points.Count(_ => _.Y == minY) == 1)
			{
				var width = maxX - minX > 1 ? maxX - minX : 1;
				return maxY != minY + 1
					? new Rectangle() {X = minX, Y = minY + 1, Height = maxY - minY - 1, Width = width}
					: new Rectangle() {X = minX, Y = maxY, Height = 1, Width = width};
			}
			else
			{
				throw new ArgumentException("Can't create rectangle!");
			}
		}
	}
}
