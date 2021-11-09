﻿using System;
using System.Drawing;

namespace TagsCloudVisualization
{
    public class PointGenerator
    {
        private readonly Point start;
        private readonly double coefficient;
        private readonly double step;
        private double angle;
        
        public PointGenerator(Point start, double coefficient = 1, double angleDelta = Math.PI / 360)
        {
            this.start = start;
            this.coefficient = coefficient;
            step = angleDelta;
        }
        
        public Point GetNextPoint()
        {
            var x = Convert.ToInt32(coefficient * Math.Cos(angle) * angle + start.X);
            var y = Convert.ToInt32(coefficient * Math.Sin(angle) * angle + start.Y);
            angle += step;
            return new Point(x, y);
        }
    }
}