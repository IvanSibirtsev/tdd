﻿using System.Drawing;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization;

namespace TagsCloudTests
{
    [TestFixture]
    public class PointGeneratorTest
    {
        private Point start;
        private ArchimedeanSpiralPointGenerator sut;
        
        [SetUp]
        public void SetUp()
        {
            start = new Point(0, 0);
            sut = new ArchimedeanSpiralPointGenerator(start);
        }

        [Test]
        public void GetNextPoint_ShouldReturnStartPoint_WhenCalledFirstTime()
        {
            var actualPoint = sut.GetNextPoint();

            actualPoint.Should().BeEquivalentTo(start);
        }
        
        [Test]
        public void GetNextPoint_ShouldReturnPointsWithIncreasingDistanceToStart()
        {
            var points = Enumerable.Range(0, 100).Select(x => sut.GetNextPoint()).ToList();
            
            var actualRadius = points.Select(point => point.DistanceTo(start)).ToList();

            var expectedRadius = actualRadius.OrderBy(x => x);
            actualRadius.Should().BeEquivalentTo(expectedRadius);
        }
    }
}