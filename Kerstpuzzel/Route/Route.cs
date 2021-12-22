using System;
using System.Collections.Generic;

namespace Kerstpuzzel.Route
{
    public class Route
    {
        public Route(Node destination)
        {
            End = new Waypoint(destination);
        }

        public Route(List<Node> path)
        {
            
        }

        public Waypoint Start
        {
            get
            {
                Waypoint point = End.From;
                point.To = End;
               while (point.From != null)
                {
                    point.From.To = point;
                    point = point.From;
                    
                }
                return point;
            }
        }

        public string PrintRoute
        {
            get
            {
                string text = "Shortest route from " + Start.Reference + " to " + End.Reference + Environment.NewLine;
                
                Waypoint point = Start;

                while (point.To != null)
                {
                    text = text + " -> "  + point.Reference;
                    point = point.To;
                }
                text = text + " -> " + point.Reference;

                return text;
            }
        }

        public Waypoint End;


    }
}

