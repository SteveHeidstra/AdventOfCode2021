using Kerstpuzzel.Route;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace KerstpuzzelTests.RouteTests
{
    [TestFixture]
    public class TripTest
    {
        /*
         *        9    (5)
         *    (6)             6   
         *         2           /--(4)
         *           (3)-- / 11  /
         *      14              /
         *          9    10    15
         *     (1)            /
         *           7     (2)
         */

        private static Node Een = new Node(1);
        private static Node Twee = new Node(2);
        private static Node Drie = new Node(3);
        private static Node Vier = new Node(4);
        private static Node Vijf = new Node(5);
        private static Node Zes = new Node(6);

        private Leg EenTwee = new Leg(Een, Twee, 7);
        private Leg EenZes = new Leg(Een, Zes, 14);
        private Leg EenDrie = new Leg(Een, Drie, 9);

        private Leg TweeDrie = new Leg(Twee, Drie, 10);
        private Leg TweeVier = new Leg(Twee, Vier, 15);

        private Leg DrieZes = new Leg(Drie, Zes, 2);
        private Leg DrieVier = new Leg(Drie, Vier, 11);

        private Leg VierVijf = new Leg(Vier, Vijf, 6);
        private Leg VijfZes = new Leg(Vijf, Zes, 9);
               

        [Test]
        public void proofDijkstra()
        {
            List<Leg> legs = new List<Leg>() { };
            legs.Add(EenTwee);
            legs.Add(EenZes);
            legs.Add(EenDrie);

            legs.Add(TweeDrie);
            legs.Add(TweeVier);
            legs.Add(DrieZes);

            legs.Add(DrieVier);
            legs.Add(VierVijf);
            legs.Add(VijfZes);

            Route route = Trip.DijkstraAlgoritme(Een, Vijf, legs);
            Console.WriteLine(route.PrintRoute);

            Assert.AreEqual( Een.Reference, route.Start.Reference);
            Assert.AreEqual( Vijf.Reference, route.End.Reference);

            Assert.AreEqual(Drie.Reference, route.Start.To.Reference);
            Assert.AreEqual(Zes.Reference, route.End.From.Reference);
        }
    }
}
