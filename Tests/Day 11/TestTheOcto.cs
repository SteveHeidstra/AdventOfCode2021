using Kerstpuzzel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace AoC2021.Day_11
{
 [TestFixture]
    public class TestTheOcto
    {
        [Test]
        public void OctoFlashUpdatesNeighbourEnery()
        {
            Octopus octo = new Octopus(1,1,1);
            Octopus neigbour = new Octopus(2,2,2);

            octo.RegisterNeighbours(new List<Octopus>() { neigbour });

            octo.Energylevel = 4;
            neigbour.Energylevel = 9;

            Assert.AreEqual(4, octo.Energylevel);
            neigbour.FlashNow(1);
            Assert.AreEqual(5, octo.Energylevel);
        }

        [Test]
        public void OctoFlashesOnlyOncePerStep()
        {
            Octopus octo = new Octopus(1,1,1);
            Octopus neigbour = new Octopus(2,2,2);

            octo.RegisterNeighbours(new List<Octopus>() { neigbour });
            int octoFlashed = 0;
            octo.Flash += ((object sender, OctoEventArgs e) => { octoFlashed++; });

            octo.Energylevel = 9;
            neigbour.Energylevel = 9;
            
            Assert.AreEqual(9, octo.Energylevel);
            neigbour.ProcessStep(1);
            Assert.AreEqual(0, octo.Energylevel);
            Assert.AreEqual(1, octoFlashed);
            neigbour.ProcessStep(1);
            Assert.AreEqual(1, octoFlashed);
            octo.Energylevel = 9;
            neigbour.Energylevel = 9;
            neigbour.ProcessStep(2);
            Assert.AreEqual(2, octoFlashed);
        }
    }
}
