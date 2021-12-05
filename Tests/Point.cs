using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Point: IEquatable<Point>
    {
       
        public Point(string v)
        {
            //0,9
            string[] coordinates = v.Split(',');
            X = Convert.ToInt32(coordinates[0]);
            Y = Convert.ToInt32(coordinates[1]);
        }

        public Point(int x, int y)
        {
            //0,9
            X = x;
            Y = y;
        }

        public Point(Point p)
        {
            //0,9
            X = p.X;
            Y = p.Y;
        }

        public int X { get; set;}
        public int Y { get; set; }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
        public override int GetHashCode() => (X,Y).GetHashCode();
    }
}
