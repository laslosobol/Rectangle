using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	public class ExceptionTests
	{
		[SetUp]
		public void Setup(){}
		
		[Test]
		public void FindRectangle_OnePointIsNull_Exception()
		{
			//Arrange
			var points = new List<Point>() {new Point() {X = 1, Y = 2}, null};
			//Act and Assert
			Assert.Throws<ArgumentNullException>(() => Service.FindRectangle(points));
		}
		[Test]
		public void FindRectangle_TwoPointsHasSimilarCoordinates_Exception()
		{
			//Arrange
			var points = new List<Point>() {new Point() {X = 1, Y = 2}, new Point(){X = 1, Y = 2}};
			//Act and Assert
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(points));
		}
		[Test]
		public void FindRectangle_ListContainsLessThanTwoPoints_Exception()
		{
			//Arrange
			var points = new List<Point>() {new Point() {X = 1, Y = 2}};
			//Act and Assert
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(points));
		}
	}

	public class ServiceTests
	{
		[SetUp]
		public void Setup(){}

		[Test]
		public void FindRectangle()
		{
			//Arrange
			var points = new List<Point>()
			{
				new Point() {X = 1, Y = 2},
				new Point() {X = 3, Y = 6},
				new Point(){X = 2, Y = 4}
			};
			var expected = new Impl.Rectangle() {X = 1, Y = 2, Height = 4, Width = 1};
			//Act
			var actual = Service.FindRectangle(points);
			Console.WriteLine(actual);
			//Assert
			Assert.AreEqual((expected.GetType(), expected.X, expected.Y, expected.Height, expected.Width),
				(actual.GetType(), actual.X, actual.Y, actual.Height, actual.Width));
		}
		[Test]
		public void FindRectangle_ImpossibleToCreateRectangle()
		{
			//Arrange
			var points = new List<Point>()
			{
				new Point() {X = 1, Y = 1},
				new Point() {X = 1, Y = 2},
				new Point() {X = 1, Y = 3},
				new Point() {X = 2, Y = 1},
				new Point() {X = 2, Y = 3},
				new Point() {X = 3, Y = 1},
				new Point() {X = 3, Y = 2},
				new Point() {X = 3, Y = 3}
			};
			//Act and Assert
			Assert.Throws<ArgumentException>(() => Service.FindRectangle(points), "Can't create rectangle!");
		}
	}
}