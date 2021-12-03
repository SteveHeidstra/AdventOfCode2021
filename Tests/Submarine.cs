using Kerstpuzzel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Submarine
    {
        public Submarine()
        {
            HorizontalPosition = 0;
            Depth = 0;
            Aim = 0;
        }

        public string Command
        {
            set
            {
                string[] x = value.Split(' ');

                switch (x[0])
                {
                    case "forward":
                        Forward = int.Parse(x[1]);
                        break;
                    case "up":
                        Up = int.Parse(x[1]);
                        break;
                    case "down":
                        Down = int.Parse(x[1]);
                        break;
                    default:
                        break;
                }
            }
        }
        public int Forward
        {
            set
            {
                HorizontalPosition += value;
                Depth += (Aim * value);
            }
        }

        public int Up
        {
            set
            {
                Aim -= value;
            }
        }
        public int Down
        {
            set
            {
                Aim += value;
            }
        }

        public int HorizontalPosition { get; private set; }
        public int Depth { get; private set; }
        public int Aim { get; private set; }
        public int PowerConsumption
        {
            get
            {
                //Total lines for counting the most common number
                int totallines = DiagnosticReport.Count();

                StringBuilder gamma = new StringBuilder();
                StringBuilder epsilon = new StringBuilder();

                //Determine of the 1's or 0's have it per position
                foreach (int count in codeCounts)
                {
                    string bit = getBit(totallines, count);
                    gamma.Append(bit);
                    epsilon.Append((bit == "1" ? "0" : "1"));
                }

                //From Binary to Decimal
                int gammarate = (int)Numbers.DifferentBaseToDecimal(gamma.ToString(), 2);
                int epsilonrate = (int)Numbers.DifferentBaseToDecimal(epsilon.ToString(), 2);

                //Calculate the powerconsumption
                return gammarate * epsilonrate;
            }
        }

        private List<string> _oxygenFilteredList = null;
        private List<string> _CO2FilteredList = null;

        private List<string> OxygenFilteredList
        {
            get
            {
                if (_oxygenFilteredList == null)
                {
                    buildFilteredLists();
                }
                return _oxygenFilteredList;
            }
        }

        private List<string> CO2FilteredList
        {
            get
            {
                if (_CO2FilteredList == null)
                {
                    buildFilteredLists();
                }
                return _CO2FilteredList;
            }
        }
        private void buildFilteredLists()
        {
            //var mostCommonValueFirstBit = getBit(DiagnosticReport.Count(), codeCounts[0]);

            _oxygenFilteredList = DiagnosticReport.ToList<string>();
            _CO2FilteredList = DiagnosticReport.ToList<string>();

            int pos = 0;
            while (OxygenFilteredList.Count > 1 || CO2FilteredList.Count > 1)
            {
                string mostCommonCharacterOxygen = getBit(OxygenFilteredList.Count(), OxygenFilteredList.Count(x => x.Substring(pos, 1) == "1"));
                string mostCommonCharacterCO2gen = getBit(CO2FilteredList.Count(), CO2FilteredList.Count(x => x.Substring(pos, 1) == "1"));

                if (OxygenFilteredList.Count > 1)
                {
                    OxygenFilteredList.RemoveAll(x => x.Substring(pos, 1) != mostCommonCharacterOxygen);
                }

                if (CO2FilteredList.Count > 1)
                {
                    CO2FilteredList.RemoveAll(x => x.Substring(pos, 1) == mostCommonCharacterCO2gen);
                }
                pos++;
            }
        }

        public int LifeSupportRating
        {
            get
            {
                return OxygenGeneratorRating * CO2ScrubberRating;
            }
        }

        public int OxygenGeneratorRating
        {
            get
            {
                //To find oxygen generator rating, determine the most common value(0 or 1) in the current bit position,
                //and keep only numbers with that bit in that position.

                //The OxygenFilteredList is already split on the first posistion
                //So calculations start at position 2

                return (int)Numbers.DifferentBaseToDecimal(OxygenFilteredList.First(), 2);
            }
        }

        public int CO2ScrubberRating
        {
            get
            {
                //To find oxygen generator rating, determine the most common value(0 or 1) in the current bit position,
                //and keep only numbers with that bit in that position.

                //If 0 and 1 are equally common, keep values with a 1 in the position being considered
                return (int)Numbers.DifferentBaseToDecimal(CO2FilteredList.First(), 2);
            }
        }

        private int[] _codeCounts = null;

        private int[] codeCounts
        {
            get { return calcCodeCounts(DiagnosticReport); }
        }

        private int[] calcCodeCounts(string[] report)
        {
            if (_codeCounts == null)
            {
                //Count how many 1's there are in each position
                int[] codeCounts = new int[report.First().Length];
                foreach (string line in report)
                {
                    char[] stringCodes = line.ToCharArray();

                    int index = 0;
                    foreach (char item in stringCodes)
                    {
                        if (item == (char)49)
                        {
                            codeCounts[index]++;
                        }
                        index++;
                    }
                }
                _codeCounts = codeCounts;
            }

            return _codeCounts;

        }

        private string[] _diagnosticReport;
        public string[] DiagnosticReport
        {
            private get { return _diagnosticReport; }
            set
            {
                _diagnosticReport = value;
                _codeCounts = null;
                _oxygenFilteredList = null;
                _CO2FilteredList = null;
            }
        }

        private string getBit(int total, int count)
        {
            decimal quotient = total / 2M;
            //Als de telling meer is dan de helft van totaal dan 1 anders 0
            return count >= quotient ? "1" : "0";
        }


    }

}
