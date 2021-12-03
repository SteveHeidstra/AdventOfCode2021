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
        public int PowerConsumption { get; internal set; }

        public void ParseDiagnosticReport(string[] file)
        {
            int totallines = file.Count();
            
            int[] codeCounts = new int[file.First().Length];
            foreach (string line in file)
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

            StringBuilder gamma = new StringBuilder();
            StringBuilder epsilon = new StringBuilder();


            foreach (int count in codeCounts)
            {
                string bit = getBit(totallines, count);
                gamma.Append(bit);
                epsilon.Append((bit == "1" ? "0" : "1"));
            }
            
            int gammarate = (int)Numbers.DifferentBaseToDecimal(gamma.ToString(), 2);
            int epsilonrate = (int)Numbers.DifferentBaseToDecimal(epsilon.ToString(), 2);
            PowerConsumption = gammarate * epsilonrate;
        }

        private string getBit(int total, int count)
        {
            //Als de telling meer is dan de helft van totaal dan 1 anders 0
            return count > (total / 2) ? "1" : "0";
        }


    }

}
