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
}