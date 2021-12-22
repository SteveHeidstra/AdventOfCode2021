using Kerstpuzzel;
using Kerstpuzzel.Route;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
namespace AoC2021
{
    [TestFixture]
    public class D12_Routes
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Test]
        public void BuildTheRoutes()
        {
            string[] file = BestandHelper.Readfile(@"Input\D12P1E1.txt");
            List<Leg> legs = new List<Leg>();
            HashSet<Node> nodes = new HashSet<Node>();
            foreach (string line in file)
            {
                string[] nodesString = line.Split('-');
                Node first = nodes.Where(x => x.Reference.ToString() == nodesString[0]).Any() ? nodes.First(x => x.Reference.ToString() == nodesString[0]) : new Node(nodesString[0]);
                Node second = nodes.Where(x => x.Reference.ToString() == nodesString[1]).Any() ? nodes.First(x => x.Reference.ToString() == nodesString[1]) : new Node(nodesString[1]);
                nodes.Add(first);
                nodes.Add(second);

                legs.Add(new Leg(first, second, 0));
            }

            Node start = legs.Where(x => x.Start.Reference.ToString() == "start").Any() ? legs.Where(x => x.Start.Reference.ToString() == "start").First().Start : legs.Where(x => x.End.Reference.ToString() == "start").First().Start;
            Node end = legs.Where(x => x.Start.Reference.ToString() == "end").Any() ? legs.Where(x => x.Start.Reference.ToString() == "end").First().End : legs.Where(x => x.End.Reference.ToString() == "end").First().End;

            foreach (Leg leg in legs.Where(x => x.Contains(start)))
            {

            }

            // List<Route> routes = FindAllRoutesDepthFirst(start, end);
        }

        private void nowwhat(List<Leg> legs)
        {

         
        }

        public static List<Route> FindAllRoutesDepthFirst(Node start, Node destination)
        {

            currentPath = new List<Node>();
            List<Route> paths = FindAllRoutesBetweenTwoNodes(start, destination, currentPath);
            return paths;
        }

        private static List<Node> currentPath;
        private static List<List<Node>> allPaths;
        private static List<Route> allRoutes = new List<Route>();

        private static List<Route> FindAllRoutesBetweenTwoNodes(Node start, Node destination, List<Node> localpaths)
        {
            //Mark Current Node As Visited
            start.Visited = true;
            if (localpaths.Count == 0)
            {
                localpaths.Add(start);
            }

            if (start == destination)
            {
                allRoutes.Add(new Route(localpaths));
            }

            foreach (var node in start.Neighbours)
            {
                if (!node.Visited)
                {
                    localpaths.Add(node);
                    FindAllRoutesBetweenTwoNodes(node, destination, localpaths);
                    localpaths.Remove(node);
                }
            }
            start.Visited = false;
            return allRoutes;
        }


       
    }
}
