using System;
using System.Collections.Generic;
using System.Linq;

namespace Kerstpuzzel.Route
{
    public class Trip
    {
        //Find the shortest route

        public static Route DijkstraAlgoritme(Node currentNode, Node destination, List<Leg> distancesList)
        {
            //Het algoritme werkt als volgt:
            //A.Geef de beginknoop voorlopig afstand 0 (dat noemen we de huidige knoop) en alle andere knopen voorlopige afstand ∞ (die noemen we niet-bezochte knopen).
            currentNode.Distance = 0;
            Node node = VisitNeighbours(currentNode, distancesList);

           return new Route(destination);           
        }
              
        private static Node VisitNeighbours(Node currentNode, List<Leg> distancesList)
        {
            foreach (Node neighbour in currentNode.Neighbours)
            {
                //B.Bekijk alle directe, niet bezochte buren van de huidige knoop.
                if (neighbour.Visited) { continue; }

                //Voor elk van die knopen kun je twee afstanden vinden:
                //1.  de voorlopige afstand die er al bij staat
                //2.  de voorlopige afstand van de huidige knoop plus de lengte van de verbindingslijn vanaf de huidige knoop naar deze
                double distance = 0;

                foreach (Leg leg in distancesList)
                {
                    if ((leg.Start.Reference.Equals(currentNode.Reference) && leg.End.Reference.Equals(neighbour.Reference)) ||
                        (leg.End.Reference.Equals(currentNode.Reference) && leg.Start.Reference.Equals(neighbour.Reference)))
                    {
                        distance = leg.Length + currentNode.Distance;
                        break;
                    }
                }
                if (distance == 0) { throw new Exception("Geen afstand tussen " + currentNode.Reference + neighbour.Reference); }

                if (distance < neighbour.Distance)
                {

                    //Kies de kortste afstand van beiden.Dat wordt de nieuwe voorlopige afstand van deze knoop.
                    //Als de afstand wijzigt dan is dit de nieuwe kortste route naar deze node, de vorige route vervalt
                    neighbour.shortestLeg = new Leg(currentNode, neighbour, distance);
                    neighbour.Distance = distance;
                }
            }
            //C.Als je alle buurknopen hebt gehad wordt de huidige knoop nu een bezochte knoop.
            currentNode.Visited = true;

            //Kies als nieuwe huidige knoop de knoop met de kleinste voorlopige afstand.
            Node newNode = currentNode.Neighbours.OrderBy(x => x.Distance).FirstOrDefault(y => y.Visited == false);
            //Ga weer naar stap B.
            if (newNode == null)
            {
                return currentNode;
            }
            return VisitNeighbours(newNode, distancesList);
        }
    }
}

