using System;
using System.Collections.Generic;
using System.Linq;

namespace Kerstpuzzel
{
    public class RomanNumeral
    {
        public static int ToInt(string numeral)
        {
            if (IsValid(numeral))
            {
                return FromRoman(numeral);
            }
            throw new FormatException(numeral + " is not a valid Roman Numeral");
        }              

        public static string FromInt(int number)
        {
            throw new NotImplementedException();

            //Start at the largest: 

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

        const char V = 'V';
        const char L = 'L';
        const char D = 'D';



        public static bool IsValid(string num)
        {
            //De 'halve' symbolen V, L en D (5, 50 en 500) komen maximaal één keer in een getal voor.
            if (num.Count(v => v == V) > 1 ||
                num.Count(l => l == L) > 1 ||
                num.Count(d => d == D) > 1)
            {
                return false;
            }

            //  return true;
            //Hieronder de moderne regels

            // Hooguit drie keer hetzelfde symbool achter elkaar, dus niet VIIII maar IX.
            int achterElkaar = 0;
            char current = 'q';
            int aantalafgetrokken = 0;
            bool resetAchterelkaar = false;

            foreach (var t in num)
            {
                if (t == current)
                {
                    achterElkaar++;
                    if (achterElkaar > 3)
                    {
                        return false;
                    }
                }
                else
                {
                    resetAchterelkaar = true;
                }

                //aftrekken: current M MCIX als waarde van current < dan waarde van t dan wordt ie afgetrokken

                if (current != 'q' && FromRoman(current) < FromRoman(t))
                {
                    if (current == V || current == L || current == D) //De symbolen V, L en D worden niet gebruikt om afgetrokken te worden, dus niet VL maar XLV en niet VC maar XCV.
                    {
                        return false;
                    }

                    //Men trekt een symbool af van een symbool waarvan de waarde vijf of tien keer zo hoog is, dus niet IL maar XLIX en (ook vanwege deze regel) niet VC maar XCV.
                    if (FromRoman(current) * 5 != FromRoman(t) && FromRoman(current) * 10 != FromRoman(t))
                    {
                        return false;
                    }

                    //Van een symbool wordt hooguit één symbool afgetrokken, dus niet IIX maar VIII.
                    if (achterElkaar > 1)
                    {
                        return false;
                    }

                    if (aantalafgetrokken > 0)
                    {
                        return false;
                    }

                    aantalafgetrokken++;
                }
                else
                {
                    aantalafgetrokken = 0;
                }

                if (resetAchterelkaar)
                {
                    achterElkaar = 1;
                    resetAchterelkaar = false;
                }
                current = t;

            }

            // De notaties van de duizendtallen, de honderdtallen, de tientallen en de eenheden worden achter elkaar gezet, bijvoorbeeld:
            //45 is 40 plus 5, dit wordt XL en V, dus XLV;
            //95 is 90 plus 5, dit wordt XC en V, dus XCV;
            //49 is 40 plus 9, dit wordt XL en IX, dus XLIX;
            //126 is 100 plus 20 plus 6, dit worden C, XX en VI, dus CXXVI.
            return true;
        }

        private static int RomanValue(int index)
        {
            int basefactor = ((index % 2) * 4 + 1); // either 1 or 5...
            // ...multiplied with the exponentation of 10, if the literal is `x` or higher
            return index > 1 ? (int)(basefactor * System.Math.Pow(10.0, index / 2)) : basefactor;
        }

        private static int FromRoman(char charact)
        {
            return FromRoman(Convert.ToString(charact));
        }

        private static int FromRoman(string roman)
        {
            roman = roman.ToLower();
            string literals = "mdclxvi";
            int value , index ;
            foreach (char literal in literals)
            {
                value = RomanValue(literals.Length - literals.IndexOf(literal) - 1);
                index = roman.IndexOf(literal);
                if (index > -1)
                    return FromRoman(roman.Substring(index + 1)) + (index > 0 ? value - FromRoman(roman.Substring(0, index)) : value);
            }
            return 0;
        }

    }
}