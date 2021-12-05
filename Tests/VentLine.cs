using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class VentLine
    {

        public VentLine(string line)
        {
            //0,9 -> 2,9
            string[] points = line.Split(' ');
            StartPoint = new Point(points[0]);
            EndPoint = new Point(points[2]);

            decimal Slope = EndPoint.X == StartPoint.X ? 0 : (EndPoint.Y - StartPoint.Y) / (EndPoint.X - StartPoint.X);
            decimal Intercept = EndPoint.X == StartPoint.X ? 1 : StartPoint.Y - (Slope * StartPoint.X);

            Points = new List<Point>();

            //Verticale lijn
            if (StartPoint.X == EndPoint.X)
            {
                for (int i = Math.Min(StartPoint.Y, EndPoint.Y); i <= Math.Max(StartPoint.Y, EndPoint.Y); i++)
                {
                    Points.Add(new Point(StartPoint.X, i));
                }
                return;
            }

            for (int i = Math.Min(StartPoint.X, EndPoint.X); i <= Math.Max(StartPoint.X, EndPoint.X); i++)
            {
                Point thisPoint = new Point(i, Convert.ToInt32((i * Slope) + Intercept));
                Points.Add(new Point(thisPoint.X, thisPoint.Y));
            }
        }

        private decimal Slope { get; }
        private decimal Intercept { get; }

        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }


        public bool HorizontalOrVertical
        {
            get
            {
                return (StartPoint.X == EndPoint.X || StartPoint.Y == EndPoint.Y);
            }
        }

        public List<Point> Points { get; private set; }        
    }
}
