using Kerstpuzzel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstpuzzelTests
{
    [TestFixture]
    public class RomanNumeralTest
    {                  
        [Test]
        public void standaard_karakters_worden_herkend()
        {
            Assert.AreEqual(1, RomanNumeral.ToInt("I"));
            Assert.AreEqual(5, RomanNumeral.ToInt("V"));
            Assert.AreEqual(10, RomanNumeral.ToInt("X"));
            Assert.AreEqual(50, RomanNumeral.ToInt("L"));
            Assert.AreEqual(100, RomanNumeral.ToInt("C"));
            Assert.AreEqual(500, RomanNumeral.ToInt("D"));
            Assert.AreEqual(1000, RomanNumeral.ToInt("M"));
        }

        [Test]
        public void samengestelde_numerals_worden_herkend()
        {
            Assert.AreEqual(3, RomanNumeral.ToInt("III"));
            Assert.AreEqual(4, RomanNumeral.ToInt("IV"));
            Assert.AreEqual(7, RomanNumeral.ToInt("VII"));
            Assert.AreEqual(9, RomanNumeral.ToInt("IX"));

            Assert.AreEqual(14, RomanNumeral.ToInt("XIV"));
            Assert.AreEqual(27, RomanNumeral.ToInt("XXVII"));
            Assert.AreEqual(45, RomanNumeral.ToInt("XLV"));
            Assert.AreEqual(71, RomanNumeral.ToInt("LXXI"));

            Assert.AreEqual(93, RomanNumeral.ToInt("XCIII"));
            Assert.AreEqual(165, RomanNumeral.ToInt("CLXV"));
            Assert.AreEqual(1900, RomanNumeral.ToInt("MCM"));
            Assert.AreEqual(2102, RomanNumeral.ToInt("MMCII"));
        }

        [Test]
        public void verkeerde_numerals_zijn_niet_valid()
        {
            Assert.IsFalse(RomanNumeral.IsValid("IIX"));
            Assert.IsFalse(RomanNumeral.IsValid("VL"));
            Assert.IsFalse(RomanNumeral.IsValid("XXXX"));
        }

        [Test]
        public void verkeerde_numerals_geven_formatException()
        {
            Assert.Throws<FormatException>(() => RomanNumeral.ToInt("IIX"));
        }

        [Test]
        public void van_getal_naar_romeins_cijfer()
        {
            Assert.Throws<NotImplementedException>(() => RomanNumeral.FromInt(15));
        }

        //Van getallen naar Romeinse cijfers: 

        //    15 = 10 + 5 = X + V = XV
        //    20 = 10 + 10 = X + X = XX
        //    34 = 30 + 4 = XXX + IV = XXXIV
        //    67 = 60 + 7 = LX + VII = LXVII

        //    129 = 100 + 20 + 9 = C + XX + IX = CXXIX
        //    670 = 600 + 70 = DC + LXX = DCLXX
        //    1100 = 1000 + 100 = M + C = MC
        //    1565 = 1000 + 500 + 60 + 5 = M + D + LX + V = MDLXV

    }
}
