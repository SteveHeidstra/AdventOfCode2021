using System;
using System.Collections.Generic;

namespace Kerstpuzzel.Route
{
    public class Node
    {
        public Node(object referenceObject)
        {
            //Voor de eerste node wordt de afstand op 0 gehouden, bij alle andere nodes is deze initieel oneindig
            Distance = Double.MaxValue;
            Reference = referenceObject;
            Neighbours = new HashSet<Node>();
        }

        //Unique reference to the current node (for comparison purposes)
        public object Reference { get; private set; }

        public double Distance { get; set; }

        public HashSet<Node> Neighbours { get; set; }

        public Leg shortestLeg { get; set; }

        public bool Visited { get; set; }
    }
}
