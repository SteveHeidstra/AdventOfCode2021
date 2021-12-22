using Kerstpuzzel;
using Kerstpuzzel.Route;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    [TestFixture]
    class Day_17___Probe
    {

        public void puz1()
        {
            //x= 281 .. 311 y= -74..-54


        }

        private int[] determinePosAfterNextStep(int[] frompos)
        {
            int[] topos = new int[2];
            //        The probe's x position increases by its x velocity.
            topos[0] = frompos[0] * 2;

            //The probe's y position increases by its y velocity.
            topos[1] = frompos[1] * 2;

            //Due to drag, the probe's x velocity changes by 1 toward the value 0; that is, it decreases by 1 if it is greater than 0,
            //increases by 1 if it is less than 0, or does not change if it is already 0.
            if (topos[0] > 0)
            {
                topos[0] = topos[0] >0 ? topos[0]- 1: topos[1] + 1;
            }

            //Due to gravity, the probe's y velocity decreases by 1.
            topos[1] = topos[1] - 1;

            return topos;
        }
    }
}
