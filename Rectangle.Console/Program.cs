using System;
using System.Linq;
using Rectangle.Impl;

namespace Rectangle.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var rectangle = Service.FindRectangle(new[]
			{
				new Point(){X = 1,Y = 2},
				new Point(){X = 1,Y = 3},
				new Point(){X = 1,Y = 5},
				new Point(){X = 2, Y = 3}
			}.ToList());
			System.Console.WriteLine(rectangle.X + " " + rectangle.Y + " " + rectangle.Height + " " + rectangle.Width);
		}
	}
}
